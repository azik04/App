using App.Application.Common.DTO.Account;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Interfaces.Integrations;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Domain.Enums;
using App.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace App.Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUsers> _userManager;
    private readonly IGenericRepository<Clients> _clientRep;
    private readonly IEmailService _emailService;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountService(UserManager<ApplicationUsers> userManager,RoleManager<IdentityRole> roleManager, IGenericRepository<Clients> clientRep, IEmailService emailService)
    {
        _emailService = emailService;
        _userManager = userManager;
        _clientRep = clientRep;
        _roleManager = roleManager;
    }

    public async Task<GenericResponse<bool>> SignUpAsync(CreateIdentityDto dto)
    {
        var entity = await _userManager.FindByEmailAsync(dto.Email);
        if (entity != null)
            return GenericResponse<bool>.Fail("Пользователь с таким Email уже существует");

        var client = new Clients
        {
            Name = dto.Name,
            Surname = dto.Surname,
        };
        await _clientRep.InsertAsync(client);

        var data = new ApplicationUsers
        {
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            UserName = dto.Name + dto.Surname,
            ClientId = client.Id
        };

        var res = await _userManager.CreateAsync(data, dto.Password);
        var role = await _userManager.AddToRoleAsync(data, "Client");
        if (!res.Succeeded || !role.Succeeded)
            return GenericResponse<bool>.Fail();

    
        await SentMailAsync(data.Email, EmailTypes.ConfirmationMail);
        
        return GenericResponse<bool>.Ok(true);
    }
    
    public async Task<GenericResponse<bool>> SentMailAsync(string email, EmailTypes type)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return GenericResponse<bool>.Fail("User not found");

        bool isSent;
        string token;
        
        switch (type)
        {
            case EmailTypes.ResetPasswordMail:
                token = await _userManager.GeneratePasswordResetTokenAsync(user);
                isSent = await _emailService.SentAsync(user.Email, Domain.Enums.EmailTypes.ResetPasswordMail, token, user.Id);
                break;
            
            case EmailTypes.ConfirmationMail:
                token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                isSent = await _emailService.SentAsync(user.Email, Domain.Enums.EmailTypes.ConfirmationMail, token, user.Id);
                break;
            
            default:
                return GenericResponse<bool>.Fail("Invalid email type");
        }
        
        if (isSent == false)
            return GenericResponse<bool>.Fail("Email sending failed");

        return GenericResponse<bool>.Ok(true);
    }

    public async Task<GenericResponse<bool>> ConfirmMailAsync(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return GenericResponse<bool>.Fail("User not found");
        
        var data = await _userManager.ConfirmEmailAsync(user, token);

        return GenericResponse<bool>.Ok(true);
    }

    public async Task<GenericResponse<bool>> ResetPasswordAsync(string userId, string token, ResetPasswordDto dto)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return GenericResponse<bool>.Fail("User not found");

        var data = await _userManager.ResetPasswordAsync(user, token, dto.confirmNewPassword);
        if (!data.Succeeded)
            return GenericResponse<bool>.Fail("Something went wrong");

        return GenericResponse<bool>.Ok(true);
    }

    public async Task<GenericResponse<bool>> AddRoleAsync()
    {
        string[] roles = { "Admin", "Client", "Worker" };

        foreach (var item in roles)
        {
           await _roleManager.CreateAsync(new IdentityRole(item));
        }
        
        return GenericResponse<bool>.Ok(true);
    }
    public async Task<GenericResponse<bool>> ChangePasswordAsync(string userId, ChangePasswordDto dto)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return GenericResponse<bool>.Fail("User not found");

        var data = await _userManager.ChangePasswordAsync(user, dto.oldPassword, dto.newPassword);
        if (!data.Succeeded)
            return GenericResponse<bool>.Fail("Old Password is wrong");    
        
        return GenericResponse<bool>.Ok(true);
    }

    public async Task<GenericResponse<bool>> BanUser(string id)
    {
        var data = await _userManager.FindByIdAsync(id);
        if (data == null)
            return GenericResponse<bool>.Fail("User Not Found");

        data.LockoutEnabled = true;
        await _userManager.SetLockoutEndDateAsync(data, DateTime.Now.AddDays(3));

        return GenericResponse<bool>.Ok(true);
    }
}