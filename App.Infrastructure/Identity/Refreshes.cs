namespace App.Infrastructure.Identity;

public class Refreshes
{
    public Guid Id { get; set; }
    public string Token { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsRevoked { get; set; }
    public string UserId { get; set; }
    public ApplicationUsers User { get; set; } 
}
