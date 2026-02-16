using App.Application.Common.DTO.Auth;
using App.Application.Common.Interfaces.Auth;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Auth.Command.SignIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, TokenResponse>
{
    private readonly IAuthService _authService;
    public SignInCommandHandler (IAuthService authService)
    {
        _authService = authService; 
    }

    public async Task<TokenResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var dto = new AuthDto
        {
            Email = request.Email,
            Password = request.Password,
        };

        return await _authService.SignInAsync(dto);
    }
}
