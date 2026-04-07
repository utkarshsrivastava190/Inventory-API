namespace Elmex.InventoryApi.Models
{
    public class Product(string name, int quantity, decimal price)
    {
        public int ID { get; set; }
        public string Name { get; set; } = name;
        public int Quantity { get; set; } = quantity;
        public decimal Price { get; set; } = price;
        // --- THE RELATIONAL BRIDGE ---

        // 1. The Foreign Key (The raw number stored in the SQL Database)
        public int SupplierId { get; set; }

        // 2. The Navigation Property (The actual object C# uses to read the Supplier's data)
        public Supplier? Supplier { get; set; }

        public decimal CalculateSalePrice(decimal percent)
        {
            decimal discountedPrice = Price * (percent / 100);
            return Price - discountedPrice;
        }

        public decimal CalculateTotalDiscountedValue(decimal percent) => CalculateSalePrice(percent) * Quantity;
    }
}
