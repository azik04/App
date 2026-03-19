using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SentConfirmEmail;

public class SentConfirmEmailCommandHandler : IRequestHandler<SendConfirmEmailCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    public SentConfirmEmailCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }


    public async Task<GenericResponse<bool>> Handle(SendConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.SentConfirmMailAsync(request.UserId);
    }
}
