//using Elmex.InventoryApi.Models;

//namespace Elmex.InventoryApi.Services
//{
//    // The Class signing the Contract
//    public class InventoryService : IInventoryService
//    {
//        // The list lives here now, at the Class level, so it remembers!
//        private readonly List<Product> _inventory = new List<Product>
//    {
//        new Product("SwitchGear", 10, 500.00m),
//        new Product("Relay", 5, 150.00m),
//        new Product("Current Transformer", 50, 100.00m),
//        new Product("ELMU", 80, 600.00m) // Your custom addition!
//    };

//        public List<Product> GetInventory()
//        {
//            return _inventory;
//        }

//        // The new method to add items from the internet
//        public void AddProduct(CreateProductDto newProduct)
//        {
//            // Convert the "dumb" Record into a "smart" Product class, then add it to the list
//            var productToSave = new Product(newProduct.Name, newProduct.Quantity, newProduct.Price);
//            _inventory.Add(productToSave);
//        }
//    }
//}

using Elmex.InventoryApi.Data; // We need this to see the AppDbContext!
using Elmex.InventoryApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Elmex.InventoryApi.Services
{
    public class InventoryService : IInventoryService
    {
        // 1. The fake List is GONE! 
        // 2. We inject the Chief Database Officer (AppDbContext) instead.
        private readonly AppDbContext _context;

        public InventoryService(AppDbContext context)
        {
            _context = context;
        }

        //public List<Product> GetInventory()
        //{
        //    // The Include() command tells EF Core to do a SQL JOIN!
        //    return _context.Products.Include(p => p.Supplier).ToList();
        //}

        //public void AddProduct(CreateProductDto newProduct)
        //{
        //    // Add the SupplierId from the DTO into the new Product
        //    var productToSave = new Product(newProduct.Name, newProduct.Quantity, newProduct.Price)
        //    {
        //        SupplierId = newProduct.SupplierId
        //    };

        //    _context.Products.Add(productToSave);
        //    _context.SaveChanges();
        //}
        //public bool UpdateProduct(int id, CreateProductDto updatedProduct)
        //{
        //    // 1. Ask EF Core to find the exact row in the SQL table
        //    var existingProduct = _context.Products.Find(id);

        //    // 2. If it doesn't exist, tell the Receptionist we failed
        //    if (existingProduct == null) return false;

        //    // 3. Update the data
        //    existingProduct.Name = updatedProduct.Name;
        //    existingProduct.Quantity = updatedProduct.Quantity;
        //    existingProduct.Price = updatedProduct.Price;

        //    // 4. Save the changes permanently to SQL
        //    _context.SaveChanges();
        //    return true;
        //}

        //public bool DeleteProduct(int id)
        //{
        //    var existingProduct = _context.Products.Find(id);
        //    if (existingProduct == null) return false;

        //    // Tell EF Core to drop this row from the table
        //    _context.Products.Remove(existingProduct);
        //    _context.SaveChanges();
        //    return true;
        //}
        // 1. Add 'async' and 'Task'
        public async Task<List<Product>> GetInventoryAsync()
        {
            // 2. Add 'await' and change ToList() to ToListAsync()
            return await _context.Products.Include(p => p.Supplier).ToListAsync();
        }

        public async Task AddProductAsync(CreateProductDto newProduct)
        {
            var productToSave = new Product(newProduct.Name, newProduct.Quantity, newProduct.Price)
            {
                SupplierId = newProduct.SupplierId
            };

            _context.Products.Add(productToSave);

            // 3. We don't await the Add, we only await the SaveChanges!
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateProductAsync(int id,CreateProductDto updatedProduct)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null) return false; 

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Quantity = updatedProduct.Quantity;
            existingProduct.Price = updatedProduct.Price;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task <bool> DeleteProductAsync(int id)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if(existingProduct == null)  return false;

            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}