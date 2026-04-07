namespace Elmex.InventoryApi.Models
{
    public record CreatePurchaseOrderDto(string PoNumber, DateTime OrderDate, int OrderedQuantity,int ProductId);
}
