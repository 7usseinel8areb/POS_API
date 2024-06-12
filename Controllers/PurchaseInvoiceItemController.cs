namespace PointofSalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseInvoiceItemController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public PurchaseInvoiceItemController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpPost]
        public async Task<ActionResult<PurchaseInvoiceItem>> PostPurchaseInvoiceItem(PurchaseInvoiceItem purchaseInvoiceItem)
        {
            appDbContext.PurchaseInvoiceItems.Add(purchaseInvoiceItem);
            await appDbContext.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseInvoiceItem", new { id = purchaseInvoiceItem.Id }, purchaseInvoiceItem);
        }
    }
}
