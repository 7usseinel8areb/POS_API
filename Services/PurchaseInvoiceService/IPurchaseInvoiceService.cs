using PointofSalesApi.DTO.PurchaseInvoicesDTO;
using System.Security.Claims;

namespace PointofSalesApi.Services.PurchaseInvoiceService
{
    public interface IPurchaseInvoiceService
    {
        Task<List<PurchaseInvoiceDTO>> GetPurchaseInvoices();

        Task<PurchaseInvoiceDTO?> GetPurchaseInvoice(int id);

        Task<bool?> EditPurchaseInvoice(int id, AddPurchaseInvoiceDTO addPurchase,ClaimsPrincipal claims);

        Task<bool?> DeletePurchaseInvoice(int id);

        Task AddPurchaseInvoice(AddPurchaseInvoiceDTO addPurchase,ClaimsPrincipal user);
    }
}
