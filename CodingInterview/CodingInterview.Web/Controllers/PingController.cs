using CodingInterview.Databases;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CodingInterview.Web
{
    [ApiController]
    [Route("ping")]
    public class PingController
    {
        [HttpGet]
        public IActionResult Ping()
        {
            var message = $"{GetType().Namespace} successfully started!\n";
            
            using (var db = new SqliteDatabaseContext())
            {
                message += $"\nDatabase initialized with:\n\t{typeof(Customer).FullName} {db.Customers.Count()}\n\t{typeof(Invoice).FullName} {db.Invoices.Count()}\n\t{typeof(Item).FullName} {db.Items.Count()}\n\t{typeof(InvoiceItem).FullName} {db.Invoices.Sum(invoice => invoice.InvoiceItems.Count)}";
            }

            return new OkObjectResult(message);
        }
    }
}