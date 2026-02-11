using App.Application.Common.DTO.Jwt;

namespace App.Application.Common.Interfaces.Helpers;

public interface ITokenHelper
{
    string GenerateAccessToken(GenerateJwtDto refresh);
    string GenerateRefreshToken();
}
