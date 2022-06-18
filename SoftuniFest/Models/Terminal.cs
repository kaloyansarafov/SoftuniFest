using System.ComponentModel.DataAnnotations.Schema;

namespace SoftuniFest.Models;

public class Terminal
{
    public int Id { get; set; }
    public string MerchantId { get; set; }
    
    [ForeignKey("MerchantId")]
    public virtual User? Merchant { get; set; }
}