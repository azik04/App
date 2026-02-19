using App.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace App.Infrastructure.Repositories;

public class IdentityRepository : IIdentityRepository
{
    private readonly UserManager<ApplicationUsers> _userManager;

    public IdentityRepository(UserManager<ApplicationUsers> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUsers?> GetByEmailAsync(string email)
        => await _userManager.FindByEmailAsync(email);

    public async Task<ApplicationUsers?> GetByIdAsync(string userId)
        => await _userManager.FindByIdAsync(userId);

    public async Task<bool> CreateUserAsync(ApplicationUsers user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        return result.Succeeded;
    }

    public async Task<bool> AddToRoleAsync(ApplicationUsers user, string role)
    {
        var result = await _userManager.AddToRoleAsync(user, role);
        return result.Succeeded;
    }

    public async Task<bool> ConfirmEmailAsync(ApplicationUsers user, string token)
    {
        var result = await _userManager.ConfirmEmailAsync(user, token);
        return result.Succeeded;
    }

    public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUsers user)
        => await _userManager.GenerateEmailConfirmationTokenAsync(user);

    public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUsers user)
        => await _userManager.GeneratePasswordResetTokenAsync(user);

    public async Task<bool> ResetPasswordAsync(ApplicationUsers user, string token, string newPassword)
    {
        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
        return result.Succeeded;
    }

    public async Task<bool> ChangePasswordAsync(ApplicationUsers user, string oldPassword, string newPassword)
    {
        var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        return result.Succeeded;
    }

    public async Task<bool> LockUserAsync(ApplicationUsers user, TimeSpan lockTime)
    {
        user.LockoutEnabled = true;
        await _userManager.SetLockoutEndDateAsync(user, DateTime.UtcNow.Add(lockTime));
        return true;
    }
}
