namespace PointofSalesApi.DTO.AppUsersDTO
{
    public class AppUserDTO
    {
        [Required]
        public string EmployeeName { get; set; }

        [Required]
        [EmailAddress]
        public string EmployeeEmail { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(6000, 100000, ErrorMessage = "Salary must be a positive value and between 6,000 and 100,000")]
        public decimal SalaryPerMonth { get; set; }
    }
}
