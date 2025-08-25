using CodingInterview.Databases;
using System;

namespace CodingInterview.Web;

public class InvoiceService(ICodingInterviewDao dao) : IInvoiceService
{
    private readonly ICodingInterviewDao _dao = dao ?? throw new ArgumentException(nameof(dao));

    public Invoice Get(int id) => _dao.GetInvoice(id);
}
