namespace PointofSalesApi.DTO.PurchaseInvoicesDTO
{
    public class PurchaseInvoiceDTO
    {

        public string EmployeeName { get; set; }

        public string SupplierName { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalAmountForAllItems => InvoiceItems.Sum(i => i.TotalAmount);

        public List<PurchaseInvoiceItemDTO> InvoiceItems { get; set; } = new List<PurchaseInvoiceItemDTO>();
    }
}
