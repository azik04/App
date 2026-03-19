using App.Application.Account.Command.ChangePassword;
using App.Application.Account.Command.ConfirmEmail;
using App.Application.Account.Command.ForgetPassword;
using App.Application.Account.Command.ResetPassword;
using App.Application.Account.Command.SentConfirmEmail;
using App.Application.Account.Command.SignUp;
using App.Application.Auth.Command.GenerateAccessToken;
using App.Application.Auth.Command.SignIn;
using App.Application.Auth.Command.SignOut;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace App.Configurations
{
    public static class ValidationConfiguration
    {
        public static void AddValidationService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            //Auth
            services.AddValidatorsFromAssembly(typeof(GenerateAccessTokenCommandValidation).Assembly);
            services.AddValidatorsFromAssembly(typeof(SignInCommandValidation).Assembly);
            services.AddValidatorsFromAssembly(typeof(SignOutCommandValidation).Assembly);

            //Account
            services.AddValidatorsFromAssembly(typeof(ChangePasswordCommandValidation).Assembly);
            services.AddValidatorsFromAssembly(typeof(ConfiemEmailCommandValidation).Assembly);
            services.AddValidatorsFromAssembly(typeof(ForgetPasswordCommandValidation).Assembly);
            services.AddValidatorsFromAssembly(typeof(ResetPasswordCommandValidation).Assembly);
            services.AddValidatorsFromAssembly(typeof(SentConfirmEmailCommandValidation).Assembly);
            services.AddValidatorsFromAssembly(typeof(SignUpCommandValidation).Assembly);
        }
    }
}
