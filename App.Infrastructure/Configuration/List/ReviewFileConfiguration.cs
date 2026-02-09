using App.Domain.Entities.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.List;

public class ReviewFileConfiguration : IEntityTypeConfiguration<ReviewFiles>
{
    public void Configure(EntityTypeBuilder<ReviewFiles> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Review).WithMany(x => x.ReviewFile).HasForeignKey(x => x.ReviewId).OnDelete(DeleteBehavior.Restrict);
    }
}
