using CodingInterview.Web;
using System;
using Xunit;

namespace CodingInterview.Tests
{
    public class CustomerControllerTests : MockingTestBase<CustomerController>
    {
        private readonly Random _random = new();

        [Fact]
        public void Get()
        {
            var id = _random.Next();

            Assert.Throws<NotImplementedException>(() => ClassUnderTest.Get(id));
        }
    }
}