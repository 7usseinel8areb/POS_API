namespace PointofSalesApi.DTO.CustomerDTO
{
    public class GetCustomerDTO : CustomerDTO
    {
        public int NumberOfPurchases => InvoiceDateAndId.Count;
        public Dictionary<DateTime, int> InvoiceDateAndId { get; set; } = new Dictionary<DateTime, int>();

    }
}
