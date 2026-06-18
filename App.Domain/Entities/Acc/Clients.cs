using App.Domain.Entities.List;
using App.Domain.Entities.Main;
using App.Domain.Entities.Rel;

namespace App.Domain.Entities.Acc;

public class Clients
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string FilePath { get; set; }
    public List<Jobs> Job { get; set; }
    public List<Reviews> Review { get; set; }
    public List<Sms> Sms { get; set; }
    public List<Addresses> Adresses { get; set; }
}
