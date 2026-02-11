using App.Application.Common.DTO.Identity;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SignUp;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand, GenericResponse<bool>>
{
    private readonly IIdentityService _identityService;
    public SignUpCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }


    public async Task<GenericResponse<bool>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.SignUpAsync(request.Dto);
    }
}