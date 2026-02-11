using App.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.Acc;

public class RefreshConfiguration : IEntityTypeConfiguration<Refreshes>
{
    public void Configure(EntityTypeBuilder<Refreshes> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User).WithMany(x => x.Refreshes).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
    }
}
