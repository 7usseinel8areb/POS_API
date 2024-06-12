namespace PointofSalesApi.Models
{
    public class SalesInvoice:Invoice
    {
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public IEnumerable<SalesInvoiceItem> salesInvoiceItems { get; set; }
    }
}
