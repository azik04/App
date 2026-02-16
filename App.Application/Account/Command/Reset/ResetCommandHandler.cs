using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.Reset;

public class ResetCommandHandler : IRequestHandler<ResetCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    public ResetCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }


    public async Task<GenericResponse<bool>> Handle(ResetCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.ResetPasswordAsync(request.Email, request.Token, request.Dto);
    }
}
