using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Auth.Command.SignOut;

public class SignOutCommandHandler : IRequestHandler<SignOutCommand, GenericResponse<bool>>
{
    private readonly IAuthService _authService;

    public SignOutCommandHandler(IAuthService authService) => _authService = authService;
    
    public async Task<GenericResponse<bool>> Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        return await _authService.SignOutAsync(request.refreshToken);
    }
}