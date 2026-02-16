using App.Domain.Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.Main;

public class JobConfiguration : IEntityTypeConfiguration<Jobs>
{
    public void Configure(EntityTypeBuilder<Jobs> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Client).WithMany(x => x.Job).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Worker).WithMany(x => x.Job).HasForeignKey(x => x.WorkerId).OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Service).WithMany(x => x.Job).HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Statuse).WithMany(x => x.Job).HasForeignKey(x => x.StatusId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Address).WithMany(x => x.Job).HasForeignKey(x => x.StatusId).OnDelete(DeleteBehavior.Restrict);
    }
}
