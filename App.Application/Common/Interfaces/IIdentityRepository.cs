using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Common.Interfaces
{
    public interface IIdentityRepository
    {
        Task<ApplicationUsers?> GetByEmailAsync(string email);
        Task<ApplicationUsers?> GetByIdAsync(string userId);
        Task<bool> CreateUserAsync(ApplicationUsers user, string password);
        Task<bool> AddToRoleAsync(ApplicationUsers user, string role);
        Task<bool> ConfirmEmailAsync(ApplicationUsers user, string token);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUsers user);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUsers user);
        Task<bool> ResetPasswordAsync(ApplicationUsers user, string token, string newPassword);
        Task<bool> ChangePasswordAsync(ApplicationUsers user, string oldPassword, string newPassword);
        Task<bool> LockUserAsync(ApplicationUsers user, TimeSpan lockTime);
    }
}
