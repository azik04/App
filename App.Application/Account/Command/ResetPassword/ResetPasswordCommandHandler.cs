using App.Application.Common.DTO.Account;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.ResetPassword;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    public ResetPasswordCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }


    public async Task<GenericResponse<bool>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var dto = new ResetPasswordDto()
        {
            confirmNewPassword = request.ConfirmNewPassword,
            newPassword = request.NewPassword,
        };

        return await _accountService.ResetPasswordAsync(request.UserId, request.Token, dto);
    }
}
