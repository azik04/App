using FluentValidation;

namespace App.Application.Address.Command.Create;

public class CreateAddressCommandValidation : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidation()
    {
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.AppId).NotEmpty();
        RuleFor(x => x.X).NotEmpty();
        RuleFor(x => x.Y).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}
