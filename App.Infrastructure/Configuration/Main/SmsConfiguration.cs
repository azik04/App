using App.Domain.Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.Main;

public class SmsConfiguration : IEntityTypeConfiguration<Sms>
{
    public void Configure(EntityTypeBuilder<Sms> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Client).WithMany(x => x.Sms).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Worker).WithMany(x => x.Sms).HasForeignKey(x => x.WorkerId).OnDelete(DeleteBehavior.Restrict);
    }
}

