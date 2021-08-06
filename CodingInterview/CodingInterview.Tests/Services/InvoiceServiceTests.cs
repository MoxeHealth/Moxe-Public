using CodingInterview.Databases;
using CodingInterview.Web;
using Moq;
using System;
using Xunit;

namespace CodingInterview.Tests
{
    public class InvoiceServiceTests : MockingTestBase<InvoiceService>
    {
        private readonly Random _random = new Random();

        [Fact]
        public void GetInvoice()
        {
            var id = _random.Next();

            ClassUnderTest.Get(id);

            AutoMocker.Mock<ICodingInterviewDao>().Verify(x => x.GetInvoice(id), Times.Once);
        }
    }
}
