namespace PointofSalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        public ISupplierService SupplierService { get; }

        public SupplierController(ISupplierService supplierService)
        {
            SupplierService = supplierService;
        }
        [HttpGet]
        public ActionResult GetSuppliers()
        {
            var suppliers = SupplierService.GetSuppliers();
            return Ok(suppliers);
        }

        [HttpGet("{id:int}",Name = "GetOneSupplierRoute")]
        public ActionResult GetSupplier(int id)
        {
            var supplier = SupplierService.GetSupplier(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostSupplier(SupplierDTO supplier)
        {
            if (ModelState.IsValid)
            {
                await SupplierService.Add(supplier);
                return Created();
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PutSupplier(int id,SupplierDTO supplier)
        {
            if (ModelState.IsValid)
            {
                var isEdited = await SupplierService.Edit(id, supplier);
                if (isEdited)
                {
                    return StatusCode(204, "Data saved succesfully");
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteSupplier(int id)
        {
            bool isDeleted = SupplierService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
