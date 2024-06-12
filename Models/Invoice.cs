namespace PointofSalesApi.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [Required]
        public DateTime InvoiceDate { get; private set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal TotalAmount {  get; set; }

        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public Invoice()
        {
            InvoiceDate = DateTime.Now;
        }
    }
}
