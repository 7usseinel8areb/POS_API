namespace PointofSalesApi.DTO
{
    public class PurchaseInvoiceDTO
    {
        public DateTime Date { get; set; }
        public decimal TotalAmount {  get; set; }
        public string EmployeeName { get; set; }
        public ICollection<PurchaseInvoiceItem> InvoiceItems { get; set; } = new List<PurchaseInvoiceItem>();
    }
}
