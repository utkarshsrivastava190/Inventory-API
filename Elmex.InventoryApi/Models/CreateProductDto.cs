namespace Elmex.InventoryApi.Models
{
    // A Record is perfect for DTOs. It just holds data securely.
    public record CreateProductDto(string Name, int Quantity, decimal Price, int SupplierId);
}
