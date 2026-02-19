namespace App.Application.Address.Command.Update;

public sealed record UpdateAddressRequest(string Name, string X, string Y, string? Address);
