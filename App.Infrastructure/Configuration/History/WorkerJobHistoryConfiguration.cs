using App.Domain.Entities.History;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.History;

public class WorkerJobHistoryConfiguration : IEntityTypeConfiguration<Domain.Entities.History.WorkerJobHistories>
{
    public void Configure(EntityTypeBuilder<WorkerJobHistories> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Jobs).WithMany(x => x.WorkerJobHistory).HasForeignKey(x => x.JobId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.WorkerJob).WithMany(x => x.WorkerJobHistories).HasForeignKey(x => x.WorkerJobId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Workers).WithMany(x => x.WorkerJobHistory).HasForeignKey(x => x.WorkerId).OnDelete(DeleteBehavior.Restrict);
    }
}
