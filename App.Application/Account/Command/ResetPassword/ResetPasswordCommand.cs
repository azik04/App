using App.Application.Common.DTO.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.ResetPassword;

public sealed record ResetPasswordCommand(string UserId, string Token, string NewPassword, string ConfirmNewPassword) : IRequest<GenericResponse<bool>>;

