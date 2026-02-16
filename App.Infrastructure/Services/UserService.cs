using App.Application.Common.DTO.User;
using App.Application.Common.Interfaces.User;
using App.Application.Common.Responses;
using App.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUsers> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<ApplicationUsers> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<GenericResponse<List<GetAllUserDto>>> GetAllUsersAsync(string role)
    {
        var roleId = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == role);

        if (role == null)
            return GenericResponse<List<GetAllUserDto>>.Fail("Role not found");

        var data = await _userManager.GetUsersInRoleAsync(roleId.Name);
        
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