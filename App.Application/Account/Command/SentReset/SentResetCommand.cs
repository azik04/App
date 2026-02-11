using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SentReset;

public sealed record SendResetCommand(string Email) : IRequest<GenericResponse<bool>>;
