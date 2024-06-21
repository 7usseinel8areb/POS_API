namespace PointofSalesApi.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [Required]
        public DateTime InvoiceDate { get; private set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal TotalAmount { get; private set; } 

        [Required]
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AppUser appUser { get; set; }

        public Invoice()
        {
            InvoiceDate = DateTime.Now;
            TotalAmount = 0;
        }
    }
}
