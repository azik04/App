namespace App.Application.Common.DTO.Client;

public class GetByIdClientDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? ActiveAddress { get; set; }
}