namespace App.Application.Common.DTO.Identity;

public class ResetPasswordDto
{
    public string newPassword { get; set; }
    public string confirmNewPassword { get; set; }
}
