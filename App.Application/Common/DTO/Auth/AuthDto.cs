namespace App.Application.Common.DTO.Auth;

public class AuthDto
{
    public string? Email { get; init; }
    public string? Password { get; init; }
    public string? Token { get; init; }
    public int AuthType { get; init; }
}
