using App.Application.Account.Command.Confirm;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Helpers;
using App.Application.Common.Interfaces.Integrations;
using App.Application.Common.Interfaces.Services;
using App.Domain.Entities.Acc;
using App.Domain.Entities.List;
using App.Domain.Entities.Rel;
using App.Infrastructure.Context;
using App.Infrastructure.Helpers;
using App.Infrastructure.Identity;
using App.Infrastructure.Integrations;
using App.Infrastructure.Repositories;
using App.Infrastructure.Services;
using App.Infrastructure.Utils.AppSettingModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ConfirmCommanHandler).Assembly));


var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(connection)
);

builder.Services.AddIdentity<ApplicationUsers, IdentityRole>()
                      .AddEntityFrameworkStores<AppDbContext>()
                      .AddDefaultTokenProviders();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenHelper, TokenHelper>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IWorkerServiceService, WorkerServiceService>();

builder.Services.AddScoped<IGenericRepository<Refreshes>, GenericRepository<Refreshes>>();
builder.Services.AddScoped<IGenericRepository<Clients>, GenericRepository<Clients>>();
builder.Services.AddScoped<IGenericRepository<Workers>, GenericRepository<Workers>>();
builder.Services.AddScoped<IGenericRepository<Services>, GenericRepository<Services>>();
builder.Services.AddScoped<IGenericRepository<WorkerServices>, GenericRepository<WorkerServices>>();

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JWT"));

builder.Services.Configure<SmtpSettings>(
    builder.Configuration.GetSection("SMTP"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
