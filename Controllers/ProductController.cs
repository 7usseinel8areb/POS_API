using PointofSalesApi.DTO.ProductsDTO;
using PointofSalesApi.Services.ProductService;

namespace PointofSalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await productService.GetProduct(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductDTO product)
        {
            if(ModelState.IsValid)
            {
                await productService.Add(product);
                return Created();
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditProduct(int id,AddProductDTO product)
        {
            if (ModelState.IsValid)
            {
                bool Edited = await productService.EditProduct(id, product);
                return Edited? StatusCode(204, "Data saved succesfully"): NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await productService.DeleteProduct(id);
            return isDeleted? NoContent(): NotFound();  
        }
    }
}
