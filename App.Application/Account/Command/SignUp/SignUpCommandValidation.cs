using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace App.Application.Account.Command.SignUp;

public class SignUpCommandValidation : AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidation()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        RuleFor(c => c.Surname).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(100);
        RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(12);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(100);
    }
}
