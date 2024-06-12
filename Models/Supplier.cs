using System.Text.Json.Serialization;

namespace PointofSalesApi.Models
{
    public class Supplier : Person
    {
        public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
