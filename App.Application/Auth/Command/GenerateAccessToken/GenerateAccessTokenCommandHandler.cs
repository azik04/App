using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Auth.Command.GenerateAccessToken;

public class GenerateAccessTokenCommandHandler : IRequestHandler<GenerateAccessTokenCommand, GenericResponse<string>>
{
    private readonly IAuthService _authService;

    public GenerateAccessTokenCommandHandler(IAuthService authService) => _authService = authService;
    
    public async Task<GenericResponse<string>> Handle(GenerateAccessTokenCommand request, CancellationToken cancellationToken)
    {
        return await _authService.GenerateAccessTokenAsync(request.refreshToken);
    }
}