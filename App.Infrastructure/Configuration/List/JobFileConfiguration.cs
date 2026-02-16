using App.Domain.Entities.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.List;

public class JobFileConfiguration : IEntityTypeConfiguration<AppFiles>
{
    public void Configure(EntityTypeBuilder<AppFiles> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Job).WithMany(x => x.JobFile).HasForeignKey(x => x.JobId).OnDelete(DeleteBehavior.Restrict);
    }
}
