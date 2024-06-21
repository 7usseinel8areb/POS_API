using Microsoft.AspNetCore.Authorization;
using PointofSalesApi.DTO.PurchaseInvoicesDTO;
using PointofSalesApi.Services.PurchaseInvoiceService;

namespace PointofSalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseInvoiceController : ControllerBase
    {
        private readonly IPurchaseInvoiceService purchaseInvoiceService;

        public PurchaseInvoiceController(IPurchaseInvoiceService purchaseInvoiceService)
        {
            this.purchaseInvoiceService = purchaseInvoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPurchases()
        {
            List<PurchaseInvoiceDTO> purchaseInvoiceDTOs = await purchaseInvoiceService.GetPurchaseInvoices();
            return Ok(purchaseInvoiceDTOs);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSinglePurchase(int id)
        {
            PurchaseInvoiceDTO? purchaseInvoice = await purchaseInvoiceService.GetPurchaseInvoice(id);
            if (purchaseInvoice == null)
            {
                return NotFound($"Purchase Invoice with the id {id} was not found!");
            }
            return Ok(purchaseInvoice);
        }

        [HttpPost("addPurchase")]
        [Authorize]
        public async Task<IActionResult> AddPurchaseInvoice(AddPurchaseInvoiceDTO addPurchase)
        {
            await purchaseInvoiceService.AddPurchaseInvoice(addPurchase,User);
            return Created();
        }

        [HttpPost("EditPurchase/{id:int}")]
        [Authorize]
        public async Task<IActionResult> EditPurchase(int id,AddPurchaseInvoiceDTO addPurchaseInvoice)
        {
            if (ModelState.IsValid)
            {
                bool? result = await purchaseInvoiceService.EditPurchaseInvoice(id, addPurchaseInvoice, User);
                if (result is null)
                {
                    return NotFound($"Purchase with the id {id} was not found!");
                }
                else if (result == true)
                {
                    return StatusCode(204, $"Data updated Succesfully by {User.Identity.Name}");
                }
            }
            return BadRequest();
        }
    }
}
