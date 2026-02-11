using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, GenericResponse<bool>>
{
    private readonly IIdentityService _identityService;
    public ChangePasswordCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<GenericResponse<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.ChangePasswordAsync(request.userId, request.dto);
    }
}
