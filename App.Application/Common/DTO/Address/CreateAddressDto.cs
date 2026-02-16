namespace App.Application.Common.DTO.Address;

public class CreateAddressDto
{
    public string Name { get; set; }
    public string X { get; set; }
    public string Y { get; set; }
    public string? Address { get; set; }
    public Guid ClientId { get; set; }
}
