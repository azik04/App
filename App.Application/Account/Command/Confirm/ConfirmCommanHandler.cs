using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.Confirm;

public class ConfirmCommanHandler : IRequestHandler<ConfirmCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    public ConfirmCommanHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }


    public async Task<GenericResponse<bool>> Handle(ConfirmCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.ConfirmMailAsync(request.UserId, request.Token);
    }
}
