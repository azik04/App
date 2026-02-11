using App.Application.Common.DTO.Account;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SignUp;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    public SignUpCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }


    public async Task<GenericResponse<bool>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.SignUpAsync(request.Dto);
    }
}