using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace App.Application.Auth.Command.GenerateAccessToken;

public class GenerateAccessTokenCommandValidation : AbstractValidator<GenerateAccessTokenCommand>
{
    public GenerateAccessTokenCommandValidation()
    {
        RuleFor(x => x.refreshToken).NotEmpty().WithMessage("Refresh token is required.");
    }
}
