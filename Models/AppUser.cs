namespace PointofSalesApi.Models
{
    public class AppUser:IdentityUser
    {
        public virtual Employee Employee { get; set; }
    }
}
