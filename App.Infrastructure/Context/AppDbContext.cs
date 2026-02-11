using App.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Context;

public partial class AppDbContext : IdentityDbContext<ApplicationUsers>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
