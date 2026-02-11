using App.Application.Common.DTO.User;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using App.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace App.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUsers> _userManager;
    public UserService(UserManager<ApplicationUsers> userManager) => _userManager = userManager;

    
    public async Task<GenericResponse<List<GetAllUserDto>>> GetAllUsersAsync(string role)
    {
        var data = await _userManager.GetUsersInRoleAsync(role);
        
        var dto = data.Select(item => new GetAllUserDto
        {
            Email = item.Email,
            Name = item.UserName,
            Surname = item.UserName,
            PhoneNumber = item.PhoneNumber,
        }).ToList();

        return GenericResponse<List<GetAllUserDto>>.Ok(dto);
    }
}