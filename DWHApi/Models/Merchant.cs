namespace DWHApi.Models;

public class Merchant
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime RegistrationDate { get; set; }
}