using System.Text.Json.Serialization;

namespace PointofSalesApi.DTO.AppUsersDTO
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
