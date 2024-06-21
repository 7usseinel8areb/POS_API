namespace PointofSalesApi.DTO.ProductsDTO
{
    public class GetProductDTO
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public decimal ProductPrice { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity per unit must be at least 1.")]

        public int QuantityPerUnit { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity in stocks must be a non-negative value.")]
        public int QuantityInStocks { get; set; }

        public string SupplierName { get; set; }

        public string CategoryName { get; set; }
    }
}
