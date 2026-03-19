using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace App.Application.Account.Command.ForgetPassword;

public class ForgetPasswordCommandValidation : AbstractValidator<SendResetCommand>
{
    public ForgetPasswordCommandValidation()
    {
        RuleFor(x => x.email).NotEmpty().EmailAddress().MaximumLength(100);
    }
}
