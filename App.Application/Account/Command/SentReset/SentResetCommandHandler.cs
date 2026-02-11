using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SentReset;

public class SentResetCommandHandler : IRequestHandler<SendResetCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    public SentResetCommandHandler(IAccountService accountService)
    {
        _accountService = accountService; 
    }


    public async Task<GenericResponse<bool>> Handle(SendResetCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.SentResetMailAsync(request.Email);
    }
}
