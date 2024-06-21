
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using PointofSalesApi.DTO.SuppliersDTO;

namespace PointofSalesApi.Services.SupplierService
{
    public class SupplierService : ISupplierService
    {
        private readonly AppDbContext appDbContext;

        public SupplierService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            var supplier = appDbContext.Suppliers.Find(id);

            if (supplier is null)
                return isDeleted;

            appDbContext.Suppliers.Remove(supplier);
            var effectedRows = appDbContext.SaveChanges();

            if (effectedRows > 0)
            {
                isDeleted = true;
            }
            return isDeleted;
        }
        public async Task Add(SupplierDTO supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException(nameof(supplier));
            }
            Supplier newSupplier = new Supplier()
            {
                Name = supplier.SupplierName,
                Email = supplier.SupplierEmail,
                PhoneNumber = supplier.SupplierPhone,

            };
            appDbContext.Suppliers.Add(newSupplier);
            appDbContext.SaveChanges();
        }

        public SupplierWithProductsAndPurchaseInvoiceDTO? GetSupplier(int id)
        {

            Supplier supplier = appDbContext.Suppliers
                .Include(s => s.Products)
                .FirstOrDefault(s => s.Id == id);
            if (supplier == null)
            {
                return null;
            }

            SupplierWithProductsAndPurchaseInvoiceDTO supplierDTO = new SupplierWithProductsAndPurchaseInvoiceDTO()
            {
                SupplierName = supplier.Name,
                SupplierEmail = supplier.Email,
                SupplierPhone = supplier.PhoneNumber,
                ProductsName = supplier.Products
                    .Select(s => s.Name)
                    .ToList()
            };
            return supplierDTO;
        }

        public List<SupplierWithProductsAndPurchaseInvoiceDTO> GetSuppliers()
        {
            List<Supplier> suppliers = appDbContext.Suppliers
                .Include(s => s.Products)
                /*.Include(s => s.PurchaseInvoices)
                .ThenInclude(s=> s.purchaseInvoiceItems)*/
                .ToList();

            List<SupplierWithProductsAndPurchaseInvoiceDTO> suppliersDto = new List<SupplierWithProductsAndPurchaseInvoiceDTO>();

            foreach (Supplier supplier in suppliers)
            {
                SupplierWithProductsAndPurchaseInvoiceDTO supplierDto = new SupplierWithProductsAndPurchaseInvoiceDTO()
                {
                    SupplierName = supplier.Name,
                    SupplierEmail = supplier.Email,
                    SupplierPhone = supplier.PhoneNumber,
                    ProductsName = supplier.Products
                    .Select(p => p.Name)
                    .ToList(),
                    /*Products = (ICollection<Product>)supplier.Products.Select(p => new ProductDTO
                    {
                        Name = p.Name,
                        Price = p.Price,
                        QuantityPerUnit = p.QuantityPerUnit,
                        QuantityInStocks = p.QuantityInStocks
                    }).ToList(),
                    purchaseInvoices = (ICollection<PurchaseInvoice>)supplier.PurchaseInvoices.Select(pi => new PurchaseInvoiceDTO
                    {
                        EmployeeName = pi.Employee.Name,
                        Date = pi.InvoiceDate,
                        TotalAmount = pi.purchaseInvoiceItems.Sum(s=>s.Quantity*s.UnitPrice),
                    }).ToList()*/
                };
                suppliersDto.Add(supplierDto);
            }
            return suppliersDto;
        }

        public async Task<bool> Edit(int id, SupplierDTO supplier)
        {
            Supplier oldSupplier = appDbContext.Suppliers.Find(id);
            if (oldSupplier == null)
            {
                return false;
            }
            oldSupplier.PhoneNumber = supplier.SupplierPhone;
            oldSupplier.Email = supplier.SupplierEmail;
            oldSupplier.Name = supplier.SupplierName;
            var affectedRows = appDbContext.SaveChanges();
            if (affectedRows > 0)
            {
                return true;
            }
            return false;
        }
    }
}
