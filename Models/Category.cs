namespace PointofSalesApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<Product> Products { get; set;}
    }
}
