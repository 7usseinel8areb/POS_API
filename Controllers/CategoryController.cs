using PointofSalesApi.DTO.CategoriesDTO;
using PointofSalesApi.Services.CategoryService;

namespace PointofSalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryService.GetCategories();
            return Ok(categories);

        }

        [HttpGet("{id:int}",Name ="GetOneategoryRoute")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await categoryService.GetCategory(id);
            if (category is null)
            {
                return NotFound(new {Message = "Category not found"});
            }
            return Ok(category);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditCategory(int id,AddCategoryDTO category)
        {
            if(ModelState.IsValid)
            {
                bool wasEdited = await categoryService.EditCategory(id, category);
                return wasEdited ? StatusCode(204, "Data Saved succesfully") : NotFound();
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var isDeletd = await categoryService.DeleteCategory(id);
            return isDeletd ? NoContent() : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                var Id = await categoryService.AddCategory(category);
                var url = Url.Link("GetOneategoryRoute", new {id = Id});
                return Created(url, "Added Succesfully");
            }
            return BadRequest();
        }
    }
}
