using App.Domain.Entities.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.List;

public class AddressConfiguration : IEntityTypeConfiguration<Addresses>
{
    public void Configure(EntityTypeBuilder<Addresses> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
