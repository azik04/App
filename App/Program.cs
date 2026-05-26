using App.Application.Account.Command.SignUp;
using App.Configurations;
using App.Infrastructure.DependencyInjection;
using App.Infrastructure.Hubs;
using App.Middleware;
using Asp.Versioning.ApiExplorer;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog();

builder.Services.AddControllers();

builder.Services.AddValidationService();

builder.Services.AuthenticationConfig(builder.Configuration);

builder.Services.AddEndpointsApiExplorer(); 

builder.Services.AddSwaggerConfig();

builder.Services.AddSignalR();

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddServices(builder.Configuration);

builder.Host.UseSerilog();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(Program).Assembly,
        typeof(SignUpCommandHandler).Assembly
    );
});

builder.Services.Cors(builder.Configuration);

builder.Services.ConfigureOptions<SwaggerOptionsConfigure>();

var app = builder.Build();


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

app.UseMiddleware<BaseMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("AppClient");

app.UseStaticFiles();

app.MapControllers();

app.MapHub<ChatHub>("/chat");

app.Run();
