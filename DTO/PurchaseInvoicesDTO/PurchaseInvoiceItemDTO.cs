namespace PointofSalesApi.DTO.PurchaseInvoicesDTO
{
    public class PurchaseInvoiceItemDTO
    {
        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }


        public decimal TotalAmount => Price * Quantity;
    }
}
