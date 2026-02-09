using App.Domain.Entities.Main;
using App.Domain.Entities.Rel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.Rel;

public class WorkerServiceConfiguration : IEntityTypeConfiguration<WorkerServices>
{
    public void Configure(EntityTypeBuilder<WorkerServices> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Service).WithMany(x => x.WorkerService).HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Worker).WithMany(x => x.WorkerService).HasForeignKey(x => x.WorkerId).OnDelete(DeleteBehavior.Restrict);
    }
}