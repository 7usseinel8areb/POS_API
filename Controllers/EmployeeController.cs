

namespace PointofSalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public EmployeeController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = appDbContext.Employees.ToList();

            if(!employees.IsNullOrEmpty())
            {
                return Ok(employees);
            }
            return NoContent();
        }
    }
}
