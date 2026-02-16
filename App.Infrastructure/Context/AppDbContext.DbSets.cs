using App.Domain.Entities.Acc;
using App.Domain.Entities.List;
using App.Domain.Entities.Main;
using App.Domain.Entities.Rel;
using App.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Context;

public partial class AppDbContext
{
    public DbSet<Clients> Client { get; set; }
    public DbSet<Workers> Worker { get; set; }
    public DbSet<Refreshes> Refresh { get; set; }

    public DbSet<AppFiles> JobFiles { get; set; }
    public DbSet<Addresses> Address { get; set; }
    public DbSet<ReviewFiles> ReviewFile { get; set; }
    public DbSet<Domain.Entities.List.Services> Service { get; set; }
    public DbSet<SmsTypes> SmsType { get; set; }
    public DbSet<Statuses> Status { get; set; }

    public DbSet<ContactUs> ContactUs { get; set; }
    public DbSet<Jobs> Jobs { get; set; }
    public DbSet<Payments> Payments { get; set; }
    public DbSet<Reviews> Reviews { get; set; }
    public DbSet<Sms> Sms { get; set; }
    public DbSet<Subscriptions> Subscriptions { get; set; }

    public DbSet<WorkerServices> WorkerServices { get; set; }
}
