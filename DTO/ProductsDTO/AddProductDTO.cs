namespace PointofSalesApi.DTO.ProductsDTO
{
    public class AddProductDTO
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

        [Required]
        [StringLength(500, ErrorMessage = "Description length can't be more than 500.")]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SupplierId { get; set; }

    }
}
