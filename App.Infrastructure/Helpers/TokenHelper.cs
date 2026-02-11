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

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()),
                new Claim(ClaimTypes.Email, dto.Email.ToString()),
            }),
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
