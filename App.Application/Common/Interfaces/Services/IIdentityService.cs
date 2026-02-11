using App.Application.Common.DTO.Identity;
using App.Application.Common.Responses;

namespace App.Application.Common.Interfaces.Services;

public interface IIdentityService
{
    Task<GenericResponse<bool>> SignUpAsync(CreateIdentityDto dto);
    Task<GenericResponse<bool>> SentConfirmMailAsync(string userId);
    Task<GenericResponse<bool>> ChangePasswordAsync(string userId, ChangePasswordDto dto);
    Task<GenericResponse<bool>> ConfirmMailAsync(string userId, string token);
    Task<GenericResponse<bool>> SentResetMailAsync(string email);
    Task<GenericResponse<bool>> ResetPasswordAsync(string email, string token, ResetPasswordDto dto);
}
