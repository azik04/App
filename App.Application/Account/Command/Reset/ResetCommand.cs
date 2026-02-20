using App.Application.Common.DTO.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.Reset;

public sealed record ResetCommand(string Email, string Token, string NewPassword, string ConfirmNewPassword) : IRequest<GenericResponse<bool>>;

