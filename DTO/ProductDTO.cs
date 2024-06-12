namespace PointofSalesApi.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityPerUnit { get; set; }
        public int QuantityInStocks { get; set; }

        public string SupplierName { get; set; }


    }
}
