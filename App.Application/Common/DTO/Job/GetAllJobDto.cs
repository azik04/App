using App.Domain.Entities.Acc;
using App.Domain.Entities.List;

namespace App.Application.Common.DTO.Job
{
    public class GetAllJobDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public string AdressName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }

        public string AppFile { get; set; }
    }
}
