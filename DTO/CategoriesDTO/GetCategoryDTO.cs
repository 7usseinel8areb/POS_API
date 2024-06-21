namespace PointofSalesApi.DTO.CategoriesDTO
{
    public class GetCategoryDTO : AddCategoryDTO
    {
        public int NumberOfProduts => Products.Count;
        public List<string> Products { get; set; } = new List<string>();
    }
}
