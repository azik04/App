using App.Application.Common.DTO.Account;
using App.Application.Common.Responses;
using App.Domain.Enums;

namespace App.Application.Common.Interfaces.Account;

public interface IAccountService
{
    Task<GenericResponse<bool>> AddRoleAsync();
    Task<GenericResponse<bool>> SignUpAsync(CreateIdentityDto dto, Guid? workerId, Guid? clientId);
    Task<GenericResponse<bool>> SentMailAsync(string email, EmailTypes type);
    Task<GenericResponse<bool>> ChangePasswordAsync(string userId, ChangePasswordDto dto);
    Task<GenericResponse<bool>> ConfirmMailAsync(string userId, string token);
    Task<GenericResponse<bool>> ResetPasswordAsync(string email, string token, ResetPasswordDto dto);
    Task<GenericResponse<bool>> BanAsync(string id);

    Task<GenericResponse<GetByIdAccount>> GetById(string id);
    Task<PaginatedResponse<GetByIdAccount>> GetAllAsync(int pageNumber, int pageSize);
}
