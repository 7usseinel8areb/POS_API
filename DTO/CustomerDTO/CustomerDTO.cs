namespace PointofSalesApi.DTO.CustomerDTO
{
    public class CustomerDTO
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }
        [Required]
        [Phone]
        public string CustomerPhone { get; set; }
    }
}
