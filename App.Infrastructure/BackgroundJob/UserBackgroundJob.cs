using App.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App.Infrastructure.BackgroundJob;

public class UserBackgroundJob : BackgroundService
{
    private readonly IServiceProvider _provider;

    public UserBackgroundJob(IServiceProvider provider)
    {
        _provider = provider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while(!stoppingToken.IsCancellationRequested)
        {
            using var scope = _provider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            var users = await db.Users.Where(u => u.UserName == "Test").ExecuteDeleteAsync(stoppingToken);

            var now = DateTime.Now;
            var nextRunTime = now.Date.AddDays(1);

            await Task.Delay(nextRunTime - now, stoppingToken);
        }
    }
}