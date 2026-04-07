using Elmex.InventoryApi.Data;
using Elmex.InventoryApi.Models;

namespace Elmex.InventoryApi.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly AppDbContext _context;

        public SupplierService(AppDbContext context)
        {
            _context = context;
        }
        public List<Supplier> GetSuppliers()
        {
            return _context.Suppliers.ToList();
        }
        public void AddSupplier(CreateServiceDto newSupplier)
        {
            var supplierToSave = new Supplier(newSupplier.Name, newSupplier.ContactPerson, newSupplier.PhoneNo);
            _context.Suppliers.Add(supplierToSave);
            _context.SaveChanges();
        }
        public bool UpdateSupplier(int id, CreateServiceDto updatedSupplier)
        {
            var existingSupplier = _context.Suppliers.Find(id);
            if (existingSupplier == null) return false;
            existingSupplier.Name = updatedSupplier.Name;
            existingSupplier.ContactPerson = updatedSupplier.ContactPerson;
            existingSupplier.PhoneNo = updatedSupplier.PhoneNo;

            _context.SaveChanges();
            return true;
        }
        public bool DeleteSupplier(int id)
        {
            var existingSupplier = _context.Suppliers.Find(id);
            if(existingSupplier == null)  return false;

            _context.Suppliers.Remove(existingSupplier);
            _context.SaveChanges();
            return true;
        }
    }
}
