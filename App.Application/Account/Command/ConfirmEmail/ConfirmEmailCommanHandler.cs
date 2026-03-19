using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.ConfirmEmail;

public class ConfirmEmailCommanHandler : IRequestHandler<ConfirmEmailCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    public ConfirmEmailCommanHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }


    public async Task<GenericResponse<bool>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.ConfirmMailAsync(request.UserId, request.Token);
    }
}
