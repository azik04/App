using App.Domain.Entities.Rel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.Rel;

public class WorkerJobConfiguration : IEntityTypeConfiguration<WorkerJobs>
{
    public void Configure(EntityTypeBuilder<WorkerJobs> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Jobs).WithMany(x => x.WorkerJob).HasForeignKey(x => x.JobId).OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Workers).WithMany(x => x.WorkerJob).HasForeignKey(x => x.WorkerId).OnDelete(DeleteBehavior.Restrict);
    }
}
