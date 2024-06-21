namespace PointofSalesApi.DTO.AppUsersDTO
{
    public class AddAppUserDTO:AppUserDTO
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set;}
        
        [Required]
        [RegularExpression("^[MF]$", ErrorMessage = "Gender must be 'M' or 'F'")]
        public char Gender { get; set;}
        [Required]
        public int DepartmentId { get; set;}

        public bool IsActive { get; set;}

        public AddAppUserDTO()
        {
            IsActive =true;
        }
    }
}
