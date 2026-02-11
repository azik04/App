using App.Domain.Entities.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.List;

public class ServiceConfiguration : IEntityTypeConfiguration<Domain.Entities.List.Services>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.List.Services> builder)
    {
        builder.HasKey(x => x.Id);
    }
}