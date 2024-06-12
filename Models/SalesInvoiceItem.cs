namespace PointofSalesApi.Models
{
    public class SalesInvoiceItem:InvoiceItem
    {
        [Required]
        public int SalesInvoiceId { get; set; }
        [ForeignKey("SalesInvoiceId")]
        public virtual SalesInvoice SalesInvoice { get; set; }
    }
}
