namespace SoftuniFest.Models;

public class Terminal
{
    public int Id { get; set; }
    public string MerchantId { get; set; }
    
    public virtual Merchant? Merchant { get; set; }
}