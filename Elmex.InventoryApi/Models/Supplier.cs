namespace Elmex.InventoryApi.Models
{
    public class Supplier(String name,String contactPerson,string phoneNo)
    {
        public int Id { get; set; }
        public string Name { get; set; } = name;
        public string ContactPerson { get; set; } = contactPerson;
        public string PhoneNo { get; set; } = phoneNo;
    }
}
