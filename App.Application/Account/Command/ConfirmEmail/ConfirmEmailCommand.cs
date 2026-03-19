using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.ConfirmEmail;

public sealed record ConfirmEmailCommand(string UserId, string Token) : IRequest<GenericResponse<bool>>;

