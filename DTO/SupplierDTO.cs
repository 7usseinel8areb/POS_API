namespace PointofSalesApi.DTO
{
    public class SupplierDTO
    {
        [Required]
        public string SupplierName { get; set; }

        [Required]
        [EmailAddress]
        public string SupplierEmail { get; set; }

        [Required]
        [Phone]
        public string SupplierPhone { get; set; }
    }
}
