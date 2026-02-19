namespace App.Application.Common.DTO.Worker;

public class GetAllWorkerDto
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Rating { get; set; } = 0;
        public string? FilePath { get; set; }
}