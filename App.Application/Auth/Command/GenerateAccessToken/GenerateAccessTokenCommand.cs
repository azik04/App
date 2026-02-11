using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Auth.Command.GenerateAccessToken;

public sealed record GenerateAccessTokenCommand(string refreshToken) : IRequest<GenericResponse<string>>;