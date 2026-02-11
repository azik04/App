using App.Domain.Entities.Main;

namespace App.Domain.Entities.List;

public class Statuses
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Jobs> Job { get; set; }
}
