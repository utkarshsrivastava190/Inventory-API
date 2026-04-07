//using Elmex.InventoryApi.Models; // This tells the controller where to find your Product class!
//using Microsoft.AspNetCore.Mvc;

//namespace Elmex.InventoryApi.Controllers
//{
//    [ApiController]
//    [Route("[controller]")] // This means the URL will be /Inventory
//    public class InventoryController : ControllerBase
//    {
//        // This tells the server: "If someone asks for data via GET, run this method!"
//        [HttpGet]
//        public IActionResult GetFullInventory()
//        {
//            // 1. Recreate your list of 3 products here!
//            List<Product> inventory = new List<Product>();
//            inventory.Add(new Product("SwitchGear", 10, 500.00m));
//            inventory.Add(new Product("Relay", 5, 150.00m));
//            inventory.Add(new Product("Current Transformer", 50, 100.00m));

//            // 2. Return the list to the internet with a "200 OK" status
//            return Ok(inventory);
//        }
//    }
//}

using Elmex.InventoryApi.Models;
using Elmex.InventoryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Elmex.InventoryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        // The Constructor: The server AUTOMATICALLY injects the service here!
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        //[HttpGet]
        //public IActionResult GetFullInventory()
        //{
        //    // The Receptionist simply asks the Worker for the data!
        //    var data = _inventoryService.GetInventory();
        //    return Ok(data);
        //}
        //// This tells the server: "If someone POSTs data here, run this method!"
        //[HttpPost]
        //public IActionResult CreateNewProduct([FromBody] CreateProductDto request)
        //{
        //    // 1. Hand the envelope to the Service Worker
        //    _inventoryService.AddProduct(request);

        //    // 2. Tell the internet it was successful (Status 201 Created)
        //    return Created();
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateProduct(int id, [FromBody] CreateProductDto request)
        //{
        //    var success = _inventoryService.UpdateProduct(id, request);

        //    if (!success) return NotFound(); // 404

        //    return NoContent(); // 204 Success!
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteProduct(int id)
        //{
        //    var success = _inventoryService.DeleteProduct(id);

        //    if (!success) return NotFound();

        //    return NoContent();
        //}
        [HttpGet]
        public async Task<IActionResult> GetInventory() // Added async Task<>
        {
            // The Receptionist waits (awaits) for the worker to finish
            var data = await _inventoryService.GetInventoryAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProduct([FromBody] CreateProductDto request)
        {
            await _inventoryService.AddProductAsync(request);
            return Created();
        }
        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateProduct(int id, [FromBody] CreateProductDto request)
        {
            var success = await _inventoryService.UpdateProductAsync(id, request);

            if (!success) return NotFound(); // 404

            return NoContent(); // 204 Success!
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteProductAsync(int id)
        {
            var success = await _inventoryService.DeleteProductAsync(id);

            if (!success) return NotFound();

            return NoContent();
        }
    }
}