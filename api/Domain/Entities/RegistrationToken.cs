namespace Domain.Entities;

public class RegistrationToken
{
    public int Id { get; set; }
    public string Email { get; set; }
    public Guid Token { get; set; }
    public DateTime Expiration { get; set; }
}