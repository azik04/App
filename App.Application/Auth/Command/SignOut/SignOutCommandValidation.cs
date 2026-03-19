using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace App.Application.Auth.Command.SignOut;

public class SignOutCommandValidation : AbstractValidator<SignOutCommand>
{
    public SignOutCommandValidation()
    {
        RuleFor(x => x.refreshToken).NotEmpty().WithMessage("Refresh token is required.");
    }
}
