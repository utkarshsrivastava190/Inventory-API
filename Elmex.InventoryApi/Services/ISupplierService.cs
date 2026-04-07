using Elmex.InventoryApi.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Elmex.InventoryApi.Services
{
    public interface ISupplierService
    {
        List<Supplier> GetSuppliers();
        void AddSupplier(CreateServiceDto newSupplier);
        bool UpdateSupplier(int id, CreateServiceDto UpdatedSupplier);
        bool DeleteSupplier(int id);
    }
}
