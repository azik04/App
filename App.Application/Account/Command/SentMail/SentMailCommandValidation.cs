using FluentValidation;

namespace App.Application.Account.Command.SentMail;

public class SentMailCommandValidation : AbstractValidator<SentMailCommand>
{
    public SentMailCommandValidation()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");

        RuleFor(x => x.EmailTypes).IsInEnum().WithMessage("EmailType is wrong.");
    }
}