using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace App.Application.Account.Command.ChangePassword;

public class ChangePasswordCommandValidation : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidation()
    {
        RuleFor(x => x.userId).NotEmpty();
        RuleFor(x => x.oldPassword).NotEmpty().MinimumLength(6).MaximumLength(100);
        RuleFor(x => x.newPassword).NotEmpty().MinimumLength(6).MaximumLength(100);
        RuleFor(x => x.confirmNewPassword).NotEmpty().MinimumLength(6).MaximumLength(100)
            .Equal(x => x.newPassword).WithMessage("Confirm password must match new password.");
    }
}
