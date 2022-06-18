using Microsoft.AspNetCore.Identity;

namespace SoftuniFest.Models;

public class User : IdentityUser
{
    public string? CardNumber { get; set; }

    public DateOnly? CardExpirationDate { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual List<Terminal>? Terminals { get; set; }
}