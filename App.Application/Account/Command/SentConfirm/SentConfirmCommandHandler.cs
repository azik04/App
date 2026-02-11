using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SentConfirm;

public class SentConfirmCommandHandler : IRequestHandler<SendConfirmCommand, GenericResponse<bool>>
{
    private readonly IIdentityService _identityService;
    public SentConfirmCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }


    public async Task<GenericResponse<bool>> Handle(SendConfirmCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.SentConfirmMailAsync(request.UserId);
    }
}
