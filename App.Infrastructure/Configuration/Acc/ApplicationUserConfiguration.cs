using App.Domain.Entities.Rel;
using App.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.Acc;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUsers>
{
    public void Configure(EntityTypeBuilder<ApplicationUsers> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(u => u.Client).WithOne().HasForeignKey<ApplicationUsers>(u => u.ClientId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(u => u.Worker).WithOne().HasForeignKey<ApplicationUsers>(u => u.WorkerId).OnDelete(DeleteBehavior.Restrict);
    }
}
