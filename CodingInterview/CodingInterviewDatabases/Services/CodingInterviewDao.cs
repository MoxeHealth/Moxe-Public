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
            Customer dbo;

            using (var db = new SqliteDatabaseContext())
            {
                dbo = db.Customers.Include(x => x.Invoices).FirstOrDefault(x => x.Id == id);
            }

            return dbo;
        }

        public Invoice GetInvoice(int id)
        {
            Invoice dbo;

            using (var db = new SqliteDatabaseContext())
            {
                dbo = db.Invoices.Include(x => x.Customer).Include(x => x.Orders).ThenInclude(x => x.Item).FirstOrDefault(x => x.Id == id);
            }

            return dbo;
        }

        public Item GetItem(int id)
        {
            Item dbo;

            using (var db = new SqliteDatabaseContext())
            {
                dbo = db.Items.FirstOrDefault(x => x.Id == id);
            }

            return dbo;
        }
    }
}