using CodingInterview.Databases;

namespace CodingInterview.Web;

public interface IInvoiceService
{
    Invoice Get(int id);
}
