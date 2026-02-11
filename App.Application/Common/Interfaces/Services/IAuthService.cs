using App.Application.Common.DTO.Auth;
using App.Application.Common.Responses;
using App.Application.Common.Responses.Base;

namespace App.Application.Common.Interfaces.Services;

public interface IAuthService
{
    Task<TokenResponse> AuthAsync(AuthDto dto);
    Task<GenericResponse<string>> GenerateRefrashToken(string refrashToken);
}
