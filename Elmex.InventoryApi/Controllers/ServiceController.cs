using Elmex.InventoryApi.Models;
using Elmex.InventoryApi.Services;
using Microsoft.AspNetCore.Mvc;
namespace Elmex.InventoryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplier;
        public SupplierController(ISupplierService supplier)
        {
            _supplier = supplier;
        }
        [HttpGet]
        public IActionResult GetSuppliers()
        {
            // The Receptionist simply asks the Worker for the data!
            var data = _supplier.GetSuppliers();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult CreateNewSupplier([FromBody] CreateServiceDto request)
        {
            _supplier.AddSupplier(request);
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateSupplier(int id, [FromBody] CreateServiceDto request)
        {
            var success = _supplier.UpdateSupplier(id, request);

            if (!success) return NotFound(); // 404

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            var success = _supplier.DeleteSupplier(id);
            if (!success) return NotFound();
            return NoContent();
        }
        }
    }

