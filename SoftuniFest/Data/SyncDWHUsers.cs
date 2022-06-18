using Microsoft.AspNetCore.Identity;
using SoftuniFest.Models;

namespace SoftuniFest.Data;

public class SyncDWHUsers
{
    public static void SyncMerchants(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        var merchantRole = roleManager.FindByNameAsync("Merchant").Result;
        if (merchantRole == null)
        {
            merchantRole = new IdentityRole("Merchant");
            roleManager.CreateAsync(merchantRole).Wait();
        }
        
        //contact the api at https://localhost:7223/api/Merchant/
        
        
        
    }
    
    
}