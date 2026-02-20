using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SentReset;

public sealed record SendResetCommand(string email) : IRequest<GenericResponse<bool>>;
