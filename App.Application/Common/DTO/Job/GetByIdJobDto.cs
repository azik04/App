using App.Application.Common.DTO.WorkerJob;
using App.Application.Common.DTO.WorkerJobHistory;

namespace App.Application.Common.DTO.Job;

public class GetByIdJobDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid ClientId { get; set; }
    public string ClientName { get; set; }
    public int AddressId { get; set; }
    public string AdressName { get; set; }
    public decimal Lat { get; set; }
    public decimal Lng { get; set; }
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public string Status { get; set; }
    public List<string> AppFile { get; set; }
    public GetByIdWorkerJobDto? WorkerJob { get; set; }
    public List<GetAllWorkerJobHistoryDto>? WorkerJobHistory { get; set; }

}
