using App.Application.Common.Responses;
using App.Domain.Enums;
using MediatR;

namespace App.Application.Account.Command.ForgetPassword;

public sealed record SendResetCommand(string email, EmailTypes EmailTypes) : IRequest<GenericResponse<bool>>;
