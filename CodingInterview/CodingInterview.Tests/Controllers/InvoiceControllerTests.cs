using CodingInterview.Databases;
using CodingInterview.Web;
using Microsoft.AspNetCore.Mvc;
using System;
using Moq;
using Xunit;

namespace CodingInterview.Tests
{
    public class InvoiceControllerTests : MockingTestBase<InvoiceController>
    {
        private readonly Random _random = new();

        [Fact]
        public void Get_Ok()
        {
            var id = _random.Next();

            AutoMocker.Mock<IInvoiceService>().Setup(x => x.Get(id)).Returns(new Invoice());

            var actual = ClassUnderTest.Get(id);

            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual);

            AutoMocker.Mock<IInvoiceService>().Verify(x => x.Get(id), Times.Once);
        }

        [Fact]
        public void Get_NotFound()
        {
            var id = _random.Next();

            AutoMocker.Mock<IInvoiceService>().Setup(x => x.Get(id)).Returns(default(Invoice));

            var actual = ClassUnderTest.Get(id);

            Assert.NotNull(actual);
            Assert.IsType<NotFoundResult>(actual);

            AutoMocker.Mock<IInvoiceService>().Verify(x => x.Get(id), Times.Once);
        }

        [Fact]
        public void GetByCustomerId()
        {
            var id = _random.Next();

            Assert.Throws<NotImplementedException>(() => ClassUnderTest.GetByCustomerId(id));
        }
    }
}