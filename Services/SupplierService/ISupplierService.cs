using PointofSalesApi.DTO.SuppliersDTO;

namespace PointofSalesApi.Services.SupplierService
{
    public interface ISupplierService
    {
        List<SupplierWithProductsAndPurchaseInvoiceDTO> GetSuppliers();

        SupplierWithProductsAndPurchaseInvoiceDTO? GetSupplier(int id);

        Task Add(SupplierDTO supplier);
        Task<bool> Edit(int id, SupplierDTO supplier);
        bool Delete(int id);
    }
}
