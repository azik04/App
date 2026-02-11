using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SentConfirm;

public sealed record SendConfirmCommand(string UserId) : IRequest<GenericResponse<bool>>;
