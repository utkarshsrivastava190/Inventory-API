//using Elmex.InventoryApi.Models;

//namespace Elmex.InventoryApi.Services
//{
//    // The Contract: You must have a method that returns a List of Products
//    public interface IInventoryService
//    {
//        List<Product> GetInventory();
//        void AddProduct(CreateProductDto newProduct); // The new rule!
//                                                      // ... your existing methods ...
//        bool UpdateProduct(int id, CreateProductDto updatedProduct);
//        bool DeleteProduct(int id);
//    }
//}

using Elmex.InventoryApi.Models;

namespace Elmex.InventoryApi.Services
{
    public interface IInventoryService
    {
        // 1. Wrapped in a Task, and renamed with "Async"
        Task<List<Product>> GetInventoryAsync();

        // 2. 'void' becomes 'Task'
        Task AddProductAsync(CreateProductDto newProduct);

        Task <bool> UpdateProductAsync(int id, CreateProductDto updatedProduct);
        Task <bool> DeleteProductAsync(int id);
    }
}