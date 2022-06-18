using Microsoft.AspNetCore.Identity;

namespace SoftuniFest.Data;

public enum ApplicationRoles
{
    Admin,
    Merchant,
    User
}
public static class SeedDataApplicationRoles
{
    public static async void SeedAspNetRoles(RoleManager<IdentityRole> roleManager)
    {

        foreach (var role in ApplicationRoles.GetValues(typeof(ApplicationRoles)))
        {
            var result =  roleManager.RoleExistsAsync(role.ToString()).Result;
            if (!result)
            { 
                await roleManager.CreateAsync(new IdentityRole(role.ToString()));
            }
        }
    }
}

