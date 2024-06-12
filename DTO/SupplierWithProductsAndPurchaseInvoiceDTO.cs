namespace PointofSalesApi.DTO
{
    public class SupplierWithProductsAndPurchaseInvoiceDTO:SupplierDTO
    {
        public List<string> ProductsName { get; set; } = new List<string>();
        /*public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<PurchaseInvoice> purchaseInvoices { get; set; } = new List<PurchaseInvoice>();*/
    }
}
