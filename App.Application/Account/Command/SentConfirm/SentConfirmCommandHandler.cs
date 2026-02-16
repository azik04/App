using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SentConfirm;

public class SentConfirmCommandHandler : IRequestHandler<SendConfirmCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    public SentConfirmCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }


    public async Task<GenericResponse<bool>> Handle(SendConfirmCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.SentConfirmMailAsync(request.UserId);
    }
}
