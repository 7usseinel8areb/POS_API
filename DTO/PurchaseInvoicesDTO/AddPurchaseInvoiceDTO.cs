using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace PointofSalesApi.DTO.PurchaseInvoicesDTO
{
    public class AddPurchaseInvoiceDTO
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ClaimsPrincipal user;

        [Required]
        public int SupplierId { get; set; }
    }
}
