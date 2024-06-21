namespace PointofSalesApi.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<AppUser> Users { get; set; }
    }
}
