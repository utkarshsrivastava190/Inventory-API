using Elmex.InventoryApi.Models;

namespace Elmex.InventoryApi.Services
{
    public interface IPurchaseOrderService
    {
        Task<List<PurchaseOrder>> GetPurchaseOrderAsync();

        Task AddPurchaseOrderAsync (CreatePurchaseOrderDto purchaseOrder);
        Task<bool> UpdatePurchaseOrderAsync(int id,CreatePurchaseOrderDto updatedPurchaseOrder);
        Task<bool> DeletePurchaseOrderAsync (int id);
    }
}
