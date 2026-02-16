using App.Application.Common.DTO.User;
using App.Application.Common.Responses;

namespace App.Application.Common.Interfaces.User;

public interface IUserService
{
    Task<GenericResponse<List<GetAllUserDto>>> GetAllUsersAsync(string role);
}