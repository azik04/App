using App.Application.Account.Command.Confirm;
using App.Application.Account.Command.Reset;
using App.Application.Account.Command.SentReset;
using App.Application.Account.Command.SignUp;
using App.Application.Auth.Command.Auth;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Helpers;
using App.Application.Common.Interfaces.Integrations;
using App.Application.Common.Interfaces.Services;
using App.Domain.Entities.Acc;
using App.Domain.Entities.List;
using App.Infrastructure.Context;
using App.Infrastructure.Helpers;
using App.Infrastructure.Identity;
using App.Infrastructure.Integrations;
using App.Infrastructure.Repositories;
using App.Infrastructure.Services;
using App.Infrastructure.Utils.AppSettingModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenHelper, TokenHelper>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IGenericRepository<Refreshes>, GenericRepository<Refreshes>>();
builder.Services.AddScoped<IGenericRepository<Clients>, GenericRepository<Clients>>();
builder.Services.AddScoped<IGenericRepository<Workers>, GenericRepository<Workers>>();
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
