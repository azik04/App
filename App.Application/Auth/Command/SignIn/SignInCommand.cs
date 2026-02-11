using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Auth.Command.SignIn;

public class SignInCommand : IRequest<TokenResponse>
{
    public string Email { get; init; }
    public string Password { get; init; }
}
