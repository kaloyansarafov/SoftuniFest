using Microsoft.AspNetCore.Identity;

namespace SoftuniFest.Models;

public class Merchant : IdentityUser
{
    public virtual List<Terminal>? Terminals { get; set; }
    public DateTime? RegistrationDate { get; set; }
}