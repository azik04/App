using App.Application.Common.Responses;
using App.Domain.Enums;

namespace App.Application.Common.Interfaces.Integrations;

public interface IEmailService
{
    Task<bool> SentAsync(string to, EmailTypes type, string token, string userId);
}
