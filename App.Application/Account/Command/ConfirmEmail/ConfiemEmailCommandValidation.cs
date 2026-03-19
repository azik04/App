using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace App.Application.Account.Command.ConfirmEmail
{
    public class ConfiemEmailCommandValidation : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfiemEmailCommandValidation()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
            RuleFor(x => x.Token).NotEmpty().WithMessage("Token is required.");
        }
    }
}
