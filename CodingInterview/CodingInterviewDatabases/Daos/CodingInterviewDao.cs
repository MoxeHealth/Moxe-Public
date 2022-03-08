using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CodingInterview.Databases
{
    [ExcludeFromCodeCoverage]
    public class CodingInterviewDao : ICodingInterviewDao
    {
        public Customer GetCustomer(int id)
        {
            Customer customerDbo;

            using (var db = new SqliteDatabaseContext())
            {
                customerDbo = db.Customers
                    .FirstOrDefault(customer => customer.Id == id);
            }

            return customerDbo;
        }

        public Invoice GetInvoice(int id)
        {
            Invoice invoiceDbo;

            using (var db = new SqliteDatabaseContext())
            {
                invoiceDbo = db.Invoices
                    .Include(invoice => invoice.Customer)
                    .Include(invoice => invoice.InvoiceItems)
                    .ThenInclude(invoiceItem => invoiceItem.Item)
                    .FirstOrDefault(invoice => invoice.Id == id);
            }

            return invoiceDbo;
        }

        public Item GetItem(int id)
        {
            Item itemDbo;

            using (var db = new SqliteDatabaseContext())
            {
                itemDbo = db.Items
                    .FirstOrDefault(item => item.Id == id);
            }

            return itemDbo;
        }
    }
}