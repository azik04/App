namespace App.Application.Common.DTO.Account;

public class ChangePasswordDto
{
    public string oldPassword { get; set; }
    public string newPassword { get; set; }
    public string confirmNewPassword { get; set; }
}
