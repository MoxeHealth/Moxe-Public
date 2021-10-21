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
        public void GetInvoice_Returns()
        {
            var id = _random.Next();

            var expected = new Invoice();

            AutoMocker.Mock<ICodingInterviewDao>().Setup(x => x.GetInvoice(id)).Returns(expected);

            var actual = ClassUnderTest.Get(id);

            Assert.Equal(expected, actual);

            AutoMocker.Mock<ICodingInterviewDao>().Verify(x => x.GetInvoice(id), Times.Once);
        }

        [Fact]
        public void GetInvoice_Throws()
        {
            var id = _random.Next();

            var expected = new TestException();

            AutoMocker.Mock<ICodingInterviewDao>().Setup(x => x.GetInvoice(id)).Throws(expected);
            
            Assert.Throws<TestException>(() => ClassUnderTest.Get(id));

            AutoMocker.Mock<ICodingInterviewDao>().Verify(x => x.GetInvoice(id), Times.Once);
        }
    }
}
