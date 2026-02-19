namespace App.Application.Common.DTO.Worker;

public class GetByIdWorkerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal Rating { get; set; }
    public string? FilePath { get; set; }
    public List<string> Service { get; set; }
    public int ReviewCount { get; set; }
    public int HistoryCount { get; set; } = 0;
}