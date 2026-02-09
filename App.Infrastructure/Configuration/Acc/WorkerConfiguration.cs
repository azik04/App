using App.Domain.Entities.Acc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.Acc;

public class WorkerConfiguration : IEntityTypeConfiguration<Workers>
{
    public void Configure(EntityTypeBuilder<Workers> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
