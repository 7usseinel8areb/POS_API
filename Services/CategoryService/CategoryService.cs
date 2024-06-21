using PointofSalesApi.DTO.CategoriesDTO;

namespace PointofSalesApi.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext appDbContext;

        public CategoryService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<int> AddCategory(AddCategoryDTO category)
        {
            Category newCategory = new Category()
            {
                Name = category.CategoryName,
            };
            appDbContext.Categories.Add(newCategory);
            await appDbContext.SaveChangesAsync();
            return newCategory.Id;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            bool isDeleted = false;
            var category = await appDbContext.Categories.FindAsync(id);
            if (category is null)
            {
                return isDeleted;
            }

            appDbContext.Categories.Remove(category);
            var affectedRows = await appDbContext.SaveChangesAsync();
            if (affectedRows > 0)
            {
                isDeleted = true;
            }
            return isDeleted;
        }

        public async Task<bool> EditCategory(int id, AddCategoryDTO category)
        {
            var oldCategory = await appDbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
            if (oldCategory is null)
            {
                return false;
            }
            oldCategory.Name = category.CategoryName;
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetCategoryDTO>> GetCategories()
        {
            List<Category> categories = await appDbContext.Categories.Include(c => c.Products).ToListAsync();
            List<GetCategoryDTO> result = categories.Select(category => new GetCategoryDTO
            {
                CategoryName = category.Name,
                Products = category.Products.Select(p => p.Name).ToList()
            }).ToList();
            
            return result;
        }
        public async Task<GetCategoryDTO> GetCategory(int id)
        {
            var category = await appDbContext
                .Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return null;
            }
            GetCategoryDTO categoryDTO = new GetCategoryDTO()
            {
                CategoryName = category.Name,
                Products = category.Products.Select(p => p.Name).ToList()
            };

            return categoryDTO;
        }
    }
}
