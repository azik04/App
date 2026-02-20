using App.Application.Common.DTO.Account;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    public ChangePasswordCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<GenericResponse<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var dto = new ChangePasswordDto()
        {
            confirmNewPassword = request.confirmNewPassword,
            newPassword = request.newPassword,
            oldPassword = request.newPassword
        };

        return await _accountService.ChangePasswordAsync(request.userId, dto);
    }
}
