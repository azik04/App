using FluentValidation;

namespace App.Application.Auth.Command.SignIn;

public class SignInCommandValidation : AbstractValidator<SignInCommand>
{
    public SignInCommandValidation()
    {


        RuleFor(x => x.AuthType).NotEmpty().WithMessage("AuthType is required.").Must(x => x == 1 || x == 2).WithMessage("AuthType must be 1 or 2.");

        When(x => x.AuthType == 1, () =>
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
        });

        When(x => x.AuthType == 2, () =>
        {
            RuleFor(x => x.Token).NotEmpty().WithMessage("Token is required.");

        });
    }
}
