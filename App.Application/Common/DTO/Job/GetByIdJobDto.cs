using App.Domain.Entities.List;

namespace App.Application.Common.DTO.Job;

public class GetByIdJobDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid ClientId { get; set; }
    public string ClientName { get; set; }
    public Guid? WorkerId { get; set; }
    public string WorkerName { get; set; }
    public decimal WorkerRating { get; set; }
    public int AddressId { get; set; }
    public string AdressName { get; set; }
    public string X { get; set; }
    public string Y { get; set; }
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public bool isActive { get; set; }
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public bool isHandled { get; set; }

    public List<string> AppFile { get; set; }
}
