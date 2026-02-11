using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.Reset;

public class ResetCommandHandler : IRequestHandler<ResetCommand, GenericResponse<bool>>
{
    private readonly IIdentityService _identityService;
    public ResetCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }


    public async Task<GenericResponse<bool>> Handle(ResetCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.ResetPasswordAsync(request.Email, request.Token, request.Dto);
    }
}
