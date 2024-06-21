using PointofSalesApi.DTO.CategoriesDTO;

namespace PointofSalesApi.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<GetCategoryDTO>> GetCategories();
        Task<GetCategoryDTO?> GetCategory(int id);

        Task<bool> EditCategory(int id, AddCategoryDTO category);

        Task<bool> DeleteCategory(int id);

        Task<int> AddCategory(AddCategoryDTO category);
    }
}
