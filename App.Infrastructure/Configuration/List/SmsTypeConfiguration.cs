using App.Domain.Entities.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.List;

public class SmsTypeConfiguration : IEntityTypeConfiguration<SmsTypes>
{
    public void Configure(EntityTypeBuilder<SmsTypes> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
