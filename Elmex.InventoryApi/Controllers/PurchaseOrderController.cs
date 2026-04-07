using Elmex.InventoryApi.Models;
using Elmex.InventoryApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace Elmex.InventoryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrder;
        public PurchaseOrderController (IPurchaseOrderService purchaseOrder)
        {
            _purchaseOrder = purchaseOrder;
        }
        [HttpGet]
        public async Task<IActionResult> GetPurchaseOrderAsync()
        {
            var data = await _purchaseOrder.GetPurchaseOrderAsync();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddPurchaseOrderAsync([FromBody] CreatePurchaseOrderDto request)
        {
            await _purchaseOrder.AddPurchaseOrderAsync(request);
            return Created();
        }
        [HttpPut("{id}")]
        public async Task <IActionResult> UpdatepurchaseOrderAsync(int id, [FromBody] CreatePurchaseOrderDto request)
        {
            var success = await _purchaseOrder.UpdatePurchaseOrderAsync(id, request);
            if (!success) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task <IActionResult> DeletePurchaseOrderAsync(int id)
        {
            var success = await _purchaseOrder.DeletePurchaseOrderAsync(id);
            if (!success) return NotFound();

            return NoContent();

        }
    }
}
