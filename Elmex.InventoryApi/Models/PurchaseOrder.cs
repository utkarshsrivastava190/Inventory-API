namespace Elmex.InventoryApi.Models
{
    public class PurchaseOrder
    {
        // Notice: No Primary Constructor at the top! EF Core loves this.

        public int Id { get; set; }
        public string PoNumber { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public int OrderedQuantity { get; set; }

        // --- The Relational Bridge ---
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}