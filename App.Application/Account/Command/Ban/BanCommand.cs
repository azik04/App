using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.Ban;

public sealed record BanCommand (string id) : IRequest<GenericResponse<bool>> 
{
}
