namespace App.Application.Common.DTO.Account;

public class GetByIdAccount
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string FilePath { get; set; }
    public Guid? ClientId { get; set; }
    public Guid? WorkerId { get; set; }
}
