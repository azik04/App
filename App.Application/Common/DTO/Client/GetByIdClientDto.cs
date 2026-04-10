namespace App.Application.Common.DTO.Client;

public class GetByIdClientDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string FilePath { get; set; }
    public string? Address { get; set; }
}