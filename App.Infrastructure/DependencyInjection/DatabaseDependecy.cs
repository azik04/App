using App.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.DependencyInjection;

public static class DatabaseDependecy
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(connection)
        );
    }
}