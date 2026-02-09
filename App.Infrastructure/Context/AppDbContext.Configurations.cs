using App.Infrastructure.Configuration.Acc;
using App.Infrastructure.Configuration.List;
using App.Infrastructure.Configuration.Main;
using App.Infrastructure.Configuration.Rel;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Context;

public partial class AppDbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ClientConfiguration());
        builder.ApplyConfiguration(new WorkerConfiguration());

        builder.ApplyConfiguration(new JobFileConfiguration());
        builder.ApplyConfiguration(new ReviewFileConfiguration());
        builder.ApplyConfiguration(new ServiceConfiguration());
        builder.ApplyConfiguration(new SmsTypeConfiguration());
        builder.ApplyConfiguration(new StatusConfiguration());

        builder.ApplyConfiguration(new ContactUsConfiguration());
        builder.ApplyConfiguration(new JobConfiguration());
        builder.ApplyConfiguration(new PaymentConfiguration());
        builder.ApplyConfiguration(new ReviewConfiguration());
        builder.ApplyConfiguration(new SmsConfiguration());
        builder.ApplyConfiguration(new SubscriptionConfiguration());

        builder.ApplyConfiguration(new WorkerServiceConfiguration());
    }
}
