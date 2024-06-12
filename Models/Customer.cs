namespace PointofSalesApi.Models
{
    public class Customer:Person
    {
        public virtual IEnumerable<SalesInvoice> SalesInvoices{ get; set; }

    }
}
