namespace CodingInterview.Web;

[ApiController]
[Route("invoice")]
public class InvoiceController(IInvoiceService invoiceService)
{
    private readonly IInvoiceService _invoiceService = invoiceService ?? throw new ArgumentException(nameof(invoiceService));

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        IActionResult result;

        var invoice = _invoiceService.Get(id);

        result = invoice == default(Invoice) ? new NotFoundResult() : new OkObjectResult(invoice);

        return result;
    }

    [HttpGet("customer/{customerId}")]
    public IActionResult GetByCustomerId(int customerId) => throw new NotImplementedException();
}
