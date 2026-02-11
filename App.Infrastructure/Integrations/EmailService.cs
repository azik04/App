using System.Net;
using App.Application.Common.Interfaces.Integrations;
using App.Application.Common.Responses;
using App.Domain.Enums;
using App.Infrastructure.Utils.AppSettingModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace App.Infrastructure.Integrations;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;
    public EmailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    public async Task<bool> SentAsync(string to, EmailTypes type, string token, string userId)
    {
        var message = new MimeMessage
        {
            Subject = "Hello World!!"
        };

        message.From.Add(new MailboxAddress("Hello", _smtpSettings.Email));
        message.To.Add(MailboxAddress.Parse(to));

        var htmlBodyResponse = await BuildBodyAsync(type, token, userId);

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = htmlBodyResponse
        };

        message.Body = bodyBuilder.ToMessageBody();

        using var client = new SmtpClient();

        var host = _smtpSettings.Server;
        var port = _smtpSettings.Port;

        await client.ConnectAsync(host, port, SecureSocketOptions.SslOnConnect);
        await client.AuthenticateAsync(_smtpSettings.Email, _smtpSettings.Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);

        return true;
    }

    private async Task<string> BuildBodyAsync(EmailTypes type, string token, string userId)
    {
        var path = type switch
        {
            EmailTypes.ConfirmationMail => "wwwroot/Emails/ConfirmEmail.html",
            EmailTypes.ResetPasswordMail => "wwwroot/Emails/ResetPassword.html"
        };

        var body = await File.ReadAllTextAsync(path);

        switch (type)
        {
            case EmailTypes.ConfirmationMail:
                body = body.Replace("{{CONFIRM_LINK}}",
                    $"http://localhost:5221/api/v1/Account/confirm?userId={userId}&token={token}");
                break;

            case EmailTypes.ResetPasswordMail:
                body = body.Replace("{{RESET_LINK}}",
                    $"http://localhost:5221/api/v1/Account/reset?userId={userId}&token={token}");
                break;
        }

        return body;
    }
}
