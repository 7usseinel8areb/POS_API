using PointofSalesApi.DTO.ProductsDTO;

namespace PointofSalesApi.Services.ProductService
{
    public interface IProductService
    {
        Task Add(AddProductDTO product);
        Task<List<GetProductDTO>> GetProducts();

        Task<GetProductDTO> GetProduct(int id);

        Task<bool> EditProduct(int id, AddProductDTO product);

        Task<bool> DeleteProduct(int id);
    }
}
