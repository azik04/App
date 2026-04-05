using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.ForgetPassword;

public class ForgetPasswordCommandHandler : IRequestHandler<SendResetCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    public ForgetPasswordCommandHandler(IAccountService accountService)
    {
        _accountService = accountService; 
    }


    public async Task<GenericResponse<bool>> Handle(SendResetCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.SentMailAsync(request.email, request.EmailTypes);
    }
}
