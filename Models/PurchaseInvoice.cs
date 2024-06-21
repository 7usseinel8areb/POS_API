namespace PointofSalesApi.Models
{
    public class PurchaseInvoice:Invoice
    {
        [Required]
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        public ICollection<PurchaseInvoiceItem> purchaseInvoiceItems { get; set; } = new List<PurchaseInvoiceItem>();
    }
}
