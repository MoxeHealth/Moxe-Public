using CodingInterview.Databases;
using System;

namespace CodingInterview.Web
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ICodingInterviewDao _dao;

        public InvoiceService(ICodingInterviewDao dao)
        {
            _dao = dao ?? throw new ArgumentException(nameof(dao));
        }

        public Invoice Get(int id)
        {
            return _dao.GetInvoice(id);
        }
    }
}
