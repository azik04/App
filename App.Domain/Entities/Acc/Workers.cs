using App.Domain.Entities.List;
using App.Domain.Entities.Main;
using App.Domain.Entities.Rel;

namespace App.Domain.Entities.Acc;

public class Workers
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal Rating { get; set; } = 0;
    public string? FilePath { get; set; }
    public bool isActive { get; set; } = false;
    public string Pin { get; set; }
    public string PhoneNumber { get; set; }
    public List<Jobs> Job { get; set; }
    public List<Reviews> Review { get; set; }
    public List<Payments> Payment { get; set; }
    public List<Subscriptions> Subscription { get; set; }
    public List<WorkerServices> WorkerService { get; set; }
    public List<Sms> Sms { get; set; }
    public List<Addresses> Adresses { get; set; }

}
