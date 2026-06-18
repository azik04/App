namespace App.Application.Common.DTO.ContactUs;

public class GetByIdContactUsDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
}
