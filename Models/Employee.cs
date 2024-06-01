namespace PointofSalesApi.Models
{
    public class Employee 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

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

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }

        public Employee()
        {
            HireDate = DateTime.Now;
            IsActive = true;
        }
    }
}
