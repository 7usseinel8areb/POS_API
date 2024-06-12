namespace PointofSalesApi.Models
{
    public class Employee :Person
    {
        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^[MF]$", ErrorMessage = "Gender must be 'M' or 'F'")]
        public char Gender { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(6000, 100000, ErrorMessage = "Salary must be a positive value and between 6,000 and 100,000")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

        public DateTime HireDate { get; private set; }

        public bool IsActive { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }

        public Employee()
        {
            HireDate = DateTime.Now;
            IsActive = true;
        }
    }
}