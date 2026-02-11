using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.Confirm;

public class ConfirmCommanHandler : IRequestHandler<ConfirmCommand, GenericResponse<bool>>
{
    private readonly IIdentityService _identityService;
    public ConfirmCommanHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }


    public async Task<GenericResponse<bool>> Handle(ConfirmCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.ConfirmMailAsync(request.UserId, request.Token);
    }
}
