namespace PointofSalesApi.Models
{
    public class PurchaseInvoiceItem:InvoiceItem
    {
        [Required]
        public int PurchaseInvoiceId { get; set; }
        [ForeignKey("PurchaseInvoiceId")]
        public virtual PurchaseInvoice PurchaseInvoice { get; set; }
    }
}
