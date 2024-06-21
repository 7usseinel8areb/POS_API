
using Microsoft.EntityFrameworkCore;
using PointofSalesApi.DTO.PurchaseInvoicesDTO;
using System.Security.Claims;

namespace PointofSalesApi.Services.PurchaseInvoiceService
{
    public class PurchaseInvoiceService : IPurchaseInvoiceService
    {
        private readonly AppDbContext appDbContext;
        private readonly UserManager<AppUser> userManager;

        public PurchaseInvoiceService(AppDbContext appDbContext,UserManager<AppUser> userManager)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
        }
        public async Task AddPurchaseInvoice(AddPurchaseInvoiceDTO addPurchase, ClaimsPrincipal user)
        {
            var appuser = await userManager.GetUserAsync(user);
            PurchaseInvoice purchaseInvoice = new PurchaseInvoice()
            {
                AppUserId = appuser.Id,
                SupplierId = addPurchase.SupplierId,
            };
            appDbContext.PurchaseInvoices.Add(purchaseInvoice);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<bool?> DeletePurchaseInvoice(int id)
        {
            bool isDeleted = false;
            var purchaseInvoice = await appDbContext.PurchaseInvoices.FindAsync(id);
            if (purchaseInvoice is null)
                return null;
            appDbContext.PurchaseInvoices.Remove(purchaseInvoice);
            var affectedRows = await appDbContext.SaveChangesAsync();
            if(affectedRows > 0)
            {
                isDeleted = true;
            }
            return isDeleted;
        }

        public async Task<bool?> EditPurchaseInvoice(int id, AddPurchaseInvoiceDTO addPurchase, ClaimsPrincipal User)
        {
            var oldPurchase = await appDbContext.PurchaseInvoices.FindAsync(id);
            var user = await userManager.GetUserAsync(User);

            if (oldPurchase is null)
                return null;

            oldPurchase.SupplierId = addPurchase.SupplierId;
            oldPurchase.AppUserId = user.Id;

            var affectedRows = await appDbContext.SaveChangesAsync();

            if (affectedRows > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<PurchaseInvoiceDTO?> GetPurchaseInvoice(int id)
        {
            var PurchaseInvoice = await appDbContext.PurchaseInvoices
                .Include(p => p.purchaseInvoiceItems)
                    .ThenInclude(p => p.Product)
                .Include(p => p.Supplier)
                .Include(p => p.appUser)
                .SingleOrDefaultAsync(p=>p.Id == id);

            if (PurchaseInvoice == null)
                return null;

            PurchaseInvoiceDTO purchaseInvoiceDTO = new PurchaseInvoiceDTO()
            {
                Date = PurchaseInvoice.InvoiceDate,
                SupplierName = PurchaseInvoice.Supplier.Name,
                EmployeeName = PurchaseInvoice.appUser.Name,
                InvoiceItems = PurchaseInvoice.purchaseInvoiceItems
                .Select(p => new PurchaseInvoiceItemDTO
                    {
                        ItemName = p.Product.Name,
                        Price = p.Product.Price ,
                        Quantity = p.Quantity
                    })
                    .ToList(),
            };
            return purchaseInvoiceDTO;
        }

        public async Task<List<PurchaseInvoiceDTO>> GetPurchaseInvoices()
        {
            var purchaseInvoices = await appDbContext.PurchaseInvoices
                .Include(p => p.purchaseInvoiceItems)
                    .ThenInclude(pi => pi.Product)
                .Include(p => p.Supplier)
                .Include(p => p.appUser)
                .ToListAsync();

            var purchaseInvoiceDTOs = purchaseInvoices.Select(purchaseInvoice => new PurchaseInvoiceDTO
            {
                Date = purchaseInvoice.InvoiceDate,
                SupplierName = purchaseInvoice.Supplier.Name,
                EmployeeName = purchaseInvoice.appUser.Name,
                InvoiceItems = purchaseInvoice.purchaseInvoiceItems
                    .Select(p => new PurchaseInvoiceItemDTO
                    {
                        ItemName = p.Product.Name,
                        Price = p.Product.Price,
                        Quantity = p.Quantity
                    })
                    .ToList()
            }).ToList();

            return purchaseInvoiceDTOs;
        }

    }
}
