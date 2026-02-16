using App.Domain.Entities.Main;

namespace App.Domain.Entities.List;

public class AppFiles
{
    public int Id { get; set; }
    public string FilePath { get; set; }
    public Guid JobId { get; set; }
    public Jobs Job { get; set; }
}
