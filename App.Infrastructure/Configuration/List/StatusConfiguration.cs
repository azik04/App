using App.Domain.Entities.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.List;

public class StatusConfiguration : IEntityTypeConfiguration<Statuses>
{
    public void Configure(EntityTypeBuilder<Statuses> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
