using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Auth.Command.Auth;

public class AuthCommand : IRequest<TokenResponse>
{
    public string Email { get; init; }
    public string Password { get; init; }
}
