using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configuration.Acc;

public class RolesConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "a1234567-1111-1111-1111-111111111111",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "d1111111-1111-1111-1111-111111111111"
            },
            new IdentityRole
            {
                Id = "a1234567-1111-1111-1111-111111111112",
                Name = "Client",
                NormalizedName = "CLIENT",
                ConcurrencyStamp = "d1111111-1111-1111-1111-111111111112"
            },
            new IdentityRole
            {
                Id = "a1234567-1111-1111-1111-111111111113",
                Name = "Worker",
                NormalizedName = "WORKER",
                ConcurrencyStamp = "d1111111-1111-1111-1111-111111111113"
            }
        );
    }
}
