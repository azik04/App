namespace App.Application.Common.DTO.Jwt;

public class GenerateJwtDto
{
    public string Role { get; set; }
    public string Email { get; set; }
    public Guid? ClientId { get; set; }
    public Guid? WorkerId { get; set; }
    public string AppId { get; set; }
    public string? ClientName { get; set; }
    public string? WorkerName { get; set; }
}
