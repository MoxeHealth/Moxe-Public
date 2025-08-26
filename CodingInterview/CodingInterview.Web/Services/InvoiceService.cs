namespace CodingInterview.Web;

public interface IInvoiceService
{
    Invoice Get(int id);
}

public class InvoiceService(ICodingInterviewDao dao) : IInvoiceService
{
    private readonly ICodingInterviewDao _dao = dao ?? throw new ArgumentException(nameof(dao));

    public Invoice Get(int id) => _dao.GetInvoice(id);
}
