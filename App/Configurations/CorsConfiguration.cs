namespace App.Configurations;

public static class CorsConfiguration 
{
    public static void Cors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(opt =>
        {
            opt.AddPolicy("AppClient", policy =>
                policy.WithOrigins("http://localhost:3000", "http://localhost:5173")
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
    }
}