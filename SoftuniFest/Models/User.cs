using Microsoft.AspNetCore.Identity;

namespace SoftuniFest.Models;

public class User : IdentityUser
{
    public string CardNumber { get; set; }
    
    public DateTime CardExpirationDate { get; set; }
    
    public DateTime? RegistrationDate { get; set; }
}