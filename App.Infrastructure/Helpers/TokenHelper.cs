using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using App.Application.Common.DTO.Jwt;
using App.Application.Common.Interfaces.Helpers;
using App.Infrastructure.Identity;
using App.Infrastructure.Utils.AppSettingModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace App.Infrastructure.Helpers;

public class TokenHelper : ITokenHelper
{
    private readonly JwtSettings _jwtSettings;
    public TokenHelper(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateAccessToken(GenerateJwtDto dto)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Key));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, dto.Email),
            new Claim(ClaimTypes.NameIdentifier, dto.AppId),
            new Claim("Role", dto.Role)
        };

        if (dto.Role == "Client" && dto.ClientId.HasValue)
        {
            claims.Add(new Claim("ClientId", dto.ClientId.Value.ToString()));
            claims.Add(new Claim("ClientName", dto.ClientName));
        }

        if (dto.Role == "Worker" && dto.WorkerId.HasValue)
        {
            claims.Add(new Claim("WorkerId", dto.WorkerId.Value.ToString()));
            claims.Add(new Claim("WorkerName", dto.WorkerName));
        } 

        var tokenDescriptor = new SecurityTokenDescriptor
        {
           
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes),
            SigningCredentials = creds,
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
        };

        var tokenHandler = new JsonWebTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return token;
    }

    public string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }
}
