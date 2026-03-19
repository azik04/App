using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SentConfirmEmail;

public sealed record SendConfirmEmailCommand(string UserId) : IRequest<GenericResponse<bool>>;
