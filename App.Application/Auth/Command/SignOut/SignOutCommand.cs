using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Auth.Command.SignOut;

public sealed record SignOutCommand (string refreshToken) : IRequest<GenericResponse<bool>>;
