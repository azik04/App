using App.Application.Common.DTO.Auth;
using App.Application.Common.Responses;
using App.Application.Common.Responses.Base;

namespace App.Application.Common.Interfaces.Auth;

public interface IAuthService
{
    Task<TokenResponse> SignInAsync(AuthDto dto);
    Task<GenericResponse<string>> GenerateAccessTokenAsync(string refrashToken);
    Task<GenericResponse<bool>> SignOutAsync(string refrashToken);
}
