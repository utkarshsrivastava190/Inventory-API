using Elmex.InventoryApi.Data; // We need this to see the AppDbContext!
using Elmex.InventoryApi.Migrations;
using Elmex.InventoryApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace Elmex.InventoryApi.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly AppDbContext _context;

        public PurchaseOrderService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<PurchaseOrder>> GetPurchaseOrderAsync()
        {
            return await _context.PurchaseOrders.Include(po =>(po.Product)).ToListAsync();
        }
        public async Task AddPurchaseOrderAsync(CreatePurchaseOrderDto purchaseOrder)
        {
            var purchaseOrderToSave = new PurchaseOrder()
            {
                PoNumber = purchaseOrder.PoNumber,
                OrderedQuantity = purchaseOrder.OrderedQuantity,
                ProductId = purchaseOrder.ProductId,
                OrderDate = DateTime.UtcNow
            };
            _context.PurchaseOrders.Add(purchaseOrderToSave);
            await _context.SaveChangesAsync();
        }
        public async Task <bool> UpdatePurchaseOrderAsync(int id,CreatePurchaseOrderDto updatedPruchaseOrder)
        {
            var existingProduct = await _context.PurchaseOrders.FindAsync(id);
            if (existingProduct == null) return false;

            existingProduct.PoNumber = updatedPruchaseOrder.PoNumber;
            existingProduct.OrderDate = updatedPruchaseOrder.OrderDate;
            existingProduct.OrderedQuantity = updatedPruchaseOrder.OrderedQuantity;
            existingProduct.ProductId = updatedPruchaseOrder.ProductId;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeletePurchaseOrderAsync(int id)
        {
            var existingProduct = await _context.PurchaseOrders.FindAsync(id);
            if(existingProduct == null) return false;
            _context.PurchaseOrders.Remove(existingProduct);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
