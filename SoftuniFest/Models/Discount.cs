using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftuniFest.Models;

public class Discount
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public string MerchantId { get; set; }
    public int Percentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    //status - active, expired, rejected, pending
    public DiscountStatus Status { get; set; }
    
    [ForeignKey("MerchantId")]
    public virtual Merchant? Merchant { get; set; }
}

public enum DiscountStatus
{
    Active,
    Expired,
    Rejected,
    Pending
}