using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SentReset;

public class SentResetCommandHandler : IRequestHandler<SendResetCommand, GenericResponse<bool>>
{
    private readonly IIdentityService _identityService;
    public SentResetCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService; 
    }


    public async Task<GenericResponse<bool>> Handle(SendResetCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.SentResetMailAsync(request.Email);
    }
}
