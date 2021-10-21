using CodingInterview.Databases;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodingInterview.Web
{
    [ApiController]
    [Route("invoice")]
    public class InvoiceController
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService ?? throw new ArgumentException(nameof(invoiceService));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult result;

            var invoice = _invoiceService.Get(id);

            if (invoice == default(Invoice))
            {
                result = new NotFoundResult();
            }
            else
            {
                result = new OkObjectResult(invoice);
            }

            return result;
        }

        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}