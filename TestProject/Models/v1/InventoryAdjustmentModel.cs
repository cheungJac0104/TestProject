
namespace TestProject.Models
{
    public class InventoryAdjustment
  {
    public string inventoryId { get; set; }
    public string supplierId { get; set; }
#nullable enable
    public string? description { get; set; }
    public string? invoiceId { get; set; }
    public string? ownerId { get; set; }
    public double? unitCost { get; set; } = 0;

#nullable disable

  }

}
