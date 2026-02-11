using App.Application.Common.DTO.Auth;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Auth.Command.Auth;

public class AuthCommandHandler : IRequestHandler<AuthCommand, TokenResponse>
{
    private readonly IAuthService _authService;
    public AuthCommandHandler (IAuthService authService)
    {
        _authService = authService; 
    }

    public async Task<TokenResponse> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        var dto = new AuthDto
        {
            Email = request.Email,
            Password = request.Password,
        };

        return await _authService.AuthAsync(dto);
    }
}
