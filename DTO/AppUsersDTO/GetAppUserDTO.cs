namespace PointofSalesApi.DTO.AppUsersDTO
{
    public class GetAppUserDTO:AppUserDTO
    {
        public string DepartmentName { get; set; }

        public string EmployeeStatus { get; set; }

        public decimal SalaryPerYear => SalaryPerMonth * 12;
    }
}
