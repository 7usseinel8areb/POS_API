using PointofSalesApi.DTO.CustomerDTO;

namespace PointofSalesApi.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<GetCustomerDTO> GetCustomerById(int id);

        Task<List<GetCustomerDTO>> GetCustomers();

        Task<bool> EditCustomer(int id,CustomerDTO customer);

        Task<bool> Deletecustomer(int id);

        Task AddCustomer(CustomerDTO customer);
    }
}
