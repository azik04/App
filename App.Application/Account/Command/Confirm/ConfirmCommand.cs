using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.Confirm;

public sealed record ConfirmCommand(string UserId, string Token) : IRequest<GenericResponse<bool>>;

