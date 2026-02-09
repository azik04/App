using App.Domain.Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.Main;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscriptions>
{
    public void Configure(EntityTypeBuilder<Subscriptions> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Payments).WithMany(x => x.Subscription).HasForeignKey(x => x.PaymentId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Worker).WithMany(x => x.Subscription).HasForeignKey(x => x.WorkerId).OnDelete(DeleteBehavior.Restrict);
    }
}

