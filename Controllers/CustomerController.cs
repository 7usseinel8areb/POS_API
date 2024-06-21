using PointofSalesApi.DTO.CustomerDTO;
using PointofSalesApi.Services.CustomerService;

namespace PointofSalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerDTO customer)
        {
            await _customerService.AddCustomer(customer);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomer(int id, CustomerDTO customer)
        {
            var result = await _customerService.EditCustomer(id, customer);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.Deletecustomer(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
