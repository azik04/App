using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Interfaces.Address;
using App.Application.Common.Interfaces.Auth;
using App.Application.Common.Interfaces.File;
using App.Application.Common.Interfaces.Helpers;
using App.Application.Common.Interfaces.Integrations;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Interfaces.Reviews;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Interfaces.User;
using App.Application.Common.Interfaces.WorkerService;
using App.Domain.Entities.Acc;
using App.Domain.Entities.List;
using App.Domain.Entities.Main;
using App.Domain.Entities.Rel;
using App.Infrastructure.Context;
using App.Infrastructure.Helpers;
using App.Infrastructure.Identity;
using App.Infrastructure.Integrations;
using App.Infrastructure.Repositories;
using App.Infrastructure.Services;
using App.Infrastructure.Utils.AppSettingModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.DependencyInjection;

public static class ServiceDependency
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUsers, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<ITokenHelper, TokenHelper>();
        services.AddScoped<IAppFileService, AppFileService>();
        services.AddScoped<IJobService, JobService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IWorkerServiceService, WorkerServiceService>();

        services.AddScoped<IGenericRepository<Refreshes>, GenericRepository<Refreshes>>();
        services.AddScoped<IGenericRepository<Clients>, GenericRepository<Clients>>();
        services.AddScoped<IGenericRepository<Addresses>, GenericRepository<Addresses>>();
        services.AddScoped<IGenericRepository<Workers>, GenericRepository<Workers>>();
        services.AddScoped<IGenericRepository<Domain.Entities.List.Services>, GenericRepository<Domain.Entities.List.Services>>();
        services.AddScoped<IGenericRepository<Reviews>, GenericRepository<Reviews>>();
        services.AddScoped<IGenericRepository<AppFiles>, GenericRepository<AppFiles>>();
        services.AddScoped<IGenericRepository<Jobs>, GenericRepository<Jobs>>();
        services.AddScoped<IGenericRepository<WorkerServices>, GenericRepository<WorkerServices>>();

        services.Configure<JwtSettings>(
            configuration.GetSection("JWT"));

        services.Configure<SmtpSettings>(
            configuration.GetSection("SMTP"));
    }
}