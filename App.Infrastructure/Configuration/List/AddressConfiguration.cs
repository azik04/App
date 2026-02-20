using App.Domain.Entities.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.List;

public class AddressConfiguration : IEntityTypeConfiguration<Addresses>
{
    public void Configure(EntityTypeBuilder<Addresses> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Client).WithMany(x => x.Adresses).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Restrict);
    }
}
