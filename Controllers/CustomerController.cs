namespace PointofSalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public CustomerController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            List<Customer> customers = appDbContext.Customers.ToList();
            if(!customers.IsNullOrEmpty())
            {
                return Ok(customers);
            }
            return NoContent();
        }
    }
}
