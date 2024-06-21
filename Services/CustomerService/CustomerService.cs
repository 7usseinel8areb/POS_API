
using PointofSalesApi.DTO.CustomerDTO;

namespace PointofSalesApi.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext appDbContext;

        public CustomerService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task AddCustomer(CustomerDTO customer)
        {
            Customer newCustomer = new Customer()
            {
                Email = customer.CustomerEmail,
                Name = customer.CustomerName,
                PhoneNumber = customer.CustomerPhone,
            };
            await appDbContext.Customers.AddAsync(newCustomer);
            await appDbContext.SaveChangesAsync();
            
        }

        public async Task<bool> Deletecustomer(int id)
        {
            bool isDeleted = false;
            Customer customer = await appDbContext.Customers.FindAsync(id);
            if (customer is null)
            {
                return isDeleted;
            }
            appDbContext.Customers.Remove(customer);
            var affectedRows = await appDbContext.SaveChangesAsync();
            if (affectedRows > 0)
            {
                isDeleted = true;
            }
            return isDeleted;
        }

        public async Task<bool> EditCustomer(int id, CustomerDTO customer)
        {
            bool wasEdited = false;
            Customer oldCustomer = await appDbContext.Customers.FindAsync(id);
            if (oldCustomer is null)
            {
                return wasEdited;
            }
            oldCustomer.PhoneNumber = customer.CustomerPhone;
            oldCustomer.Name = customer.CustomerName;
            oldCustomer.Email = customer.CustomerEmail;
            
            var affectedRows = await appDbContext.SaveChangesAsync();
            if (affectedRows > 0)
            {
                wasEdited = true;
            }
            return wasEdited;
        }

        public async Task<GetCustomerDTO> GetCustomerById(int id)
        {
            Customer customer = await appDbContext.Customers.Include(c => c.SalesInvoices).FirstOrDefaultAsync(c => c.Id == id);
            GetCustomerDTO getCustomer = new GetCustomerDTO()
            {
                CustomerEmail = customer.Email,
                CustomerName = customer.Name,
                CustomerPhone = customer.PhoneNumber,
                InvoiceDateAndId = customer.SalesInvoices
                    .Select(c => new { c.InvoiceDate, c.Id })
                    .ToDictionary(c => c.InvoiceDate, c => c.Id)

            };
            return getCustomer;
        }

        public async Task<List<GetCustomerDTO>> GetCustomers()
        {
            var customers = await appDbContext.Customers
                .Include(c => c.SalesInvoices)
                .ToListAsync();

            var getCustomerDTOs = customers.Select(customer => new GetCustomerDTO()
            {
                CustomerEmail = customer.Email,
                CustomerName = customer.Name,
                CustomerPhone = customer.PhoneNumber,
                InvoiceDateAndId = customer.SalesInvoices
                    .Select(c => new { c.InvoiceDate, c.Id })
                    .ToDictionary(c => c.InvoiceDate, c => c.Id)
            }).ToList();

            return getCustomerDTOs;
        }
    }
}
