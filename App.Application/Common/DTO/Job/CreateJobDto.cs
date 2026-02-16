using App.Domain.Entities.Acc;
using App.Domain.Entities.List;

namespace App.Application.Common.DTO.Job;

public class CreateJobDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid ClientId { get; set; }
    public Guid? WorkerId { get; set; }
    public int AddressId { get; set; }
    public int ServiceId { get; set; }
    public bool isActive { get; set; }
}
