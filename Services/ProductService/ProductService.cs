using PointofSalesApi.DTO.ProductsDTO;

namespace PointofSalesApi.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext appDbContext;

        public ProductService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task Add(AddProductDTO product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            Product newProduct = new Product()
            {
                Name = product.ProductName,
                Price = product.ProductPrice,
                QuantityInStocks = product.QuantityInStocks,
                QuantityPerUnit = product.QuantityPerUnit,
                CategoryId = product.CategoryId,
                Description = product.Description,
                SupplierId = product.SupplierId,
            };

            appDbContext.Products.Add(newProduct);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteProduct(int id)
        {
            bool isDeleted = false;
            var product = await appDbContext.Products.FindAsync(id);
            if (product is null)
            {
                return isDeleted;
            }
            appDbContext.Products.Remove(product);
            var effectedRows = await appDbContext.SaveChangesAsync();
            if (effectedRows > 0)
            {
                isDeleted = true;
            }
            return isDeleted;
        }

        public async Task<bool> EditProduct(int id, AddProductDTO product)
        {
            var oldProduct = await appDbContext.Products
                .SingleOrDefaultAsync(p => p.Id == id);

            if (oldProduct == null)
            {
                return false;
            }

            oldProduct.Name = product.ProductName;
            oldProduct.Price = product.ProductPrice;
            oldProduct.SupplierId = product.SupplierId;
            oldProduct.Description = product.Description;
            oldProduct.CategoryId = product.CategoryId;
            oldProduct.QuantityInStocks = product.QuantityInStocks;
            oldProduct.QuantityPerUnit = product.QuantityPerUnit;
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<GetProductDTO> GetProduct(int id)
        {
            var product = await appDbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            GetProductDTO getProductDTO = new GetProductDTO()
            {
                CategoryName = product.Category.Name,
                ProductName = product.Name,
                ProductPrice = product.Price,
                QuantityInStocks = product.QuantityInStocks,
                QuantityPerUnit = product.QuantityPerUnit,
                SupplierName = product.Supplier.Name,
            };

            return getProductDTO;
        }

        public async Task<List<GetProductDTO>> GetProducts()
        {
            var products = await appDbContext.Products
                .Include(p => p.Supplier)
                .Include(p => p.Category)
                .ToListAsync();
            List<GetProductDTO> productsDTO = new List<GetProductDTO>();
            GetProductDTO productDTO = new GetProductDTO();
            foreach (var product in products)
            {
                productDTO.ProductName = product.Name;
                productDTO.ProductPrice = product.Price;
                productDTO.QuantityPerUnit = product.QuantityPerUnit;
                productDTO.QuantityInStocks = product.QuantityInStocks;
                productDTO.SupplierName = product.Supplier.Name;
                productDTO.CategoryName = product.Category.Name;
                productsDTO.Add(productDTO);
            }
            return productsDTO;

        }
    }
}
