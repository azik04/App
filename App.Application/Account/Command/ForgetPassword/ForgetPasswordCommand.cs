using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.ForgetPassword;

public sealed record SendResetCommand(string email) : IRequest<GenericResponse<bool>>;
