namespace App.Application.Common.DTO.Jwt;

public class GenerateJwtDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public Guid? ClientId { get; set; }
}
