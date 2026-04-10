//using System;
//using System.Collections.Generic;
//using System.Text;
//using FluentValidation;

//namespace App.Application.Auth.Command.SignIn;

//public class SignInCommandValidation : AbstractValidator<SignInCommand>
//{
//    public SignInCommandValidation()
//    {
//        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
//            .EmailAddress().WithMessage("Invalid email format.");
//        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
//    }
//}
