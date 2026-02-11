using App.Domain.Entities.Acc;
using Microsoft.AspNetCore.Identity;

namespace App.Infrastructure.Identity;

public class ApplicationUsers : IdentityUser
{
    public Guid? ClientId { get; set; }
    public Clients? Client { get; set; }
    public Guid? WorkerId { get; set; }
    public Workers? Worker { get; set; }
    public List<Refreshes> Refreshes { get; set; } = new();
}
