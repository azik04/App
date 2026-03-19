using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace App.Application.Account.Command.SentConfirmEmail;

public class SentConfirmEmailCommandValidation : AbstractValidator<SendConfirmEmailCommand>
{
    public SentConfirmEmailCommandValidation()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
    }
}
