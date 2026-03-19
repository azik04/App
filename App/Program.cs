using System.Reflection;
using App.Application.Account.Command.SignUp;
using App.Configurations;
using App.Infrastructure.DependencyInjection;
using App.Infrastructure.Hubs;
using Asp.Versioning.ApiExplorer;
using FluentValidation;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddValidationService();

builder.Services.AddEndpointsApiExplorer(); 

builder.Services.AddSwaggerConfig();

builder.Services.AddSignalR();

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddServices(builder.Configuration);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(Program).Assembly,
        typeof(SignUpCommandHandler).Assembly
    );
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AppClient", policy =>
            policy.WithOrigins("http://localhost:3000")
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod());
});

builder.Services.ConfigureOptions<SwaggerOptionsConfigure>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.DefaultModelsExpandDepth(-1);
        foreach (var item in provider.ApiVersionDescriptions)
        {
            opt.SwaggerEndpoint($"/swagger/{item.GroupName}/swagger.json", item.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors("AppClient");

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/chat");

app.Run();
