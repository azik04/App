using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SentMail;

public class SentMailCommandHandler : IRequestHandler<SentMailCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    public SentMailCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    
    public async Task<GenericResponse<bool>> Handle(SentMailCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.SentMailAsync(request.Email , request.EmailTypes);
    }
}