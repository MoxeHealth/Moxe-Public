namespace CodingInterview.Tests;

[TestClass]
public class InvoiceServiceTests : MockingTestBase<InvoiceService>
{
    private readonly Random _random = new();

    [TestMethod]
    public void GetInvoice_Returns()
    {
        var id = _random.Next();

        var expected = new Invoice();

        AutoMocker.Mock<ICodingInterviewDao>().Setup(x => x.GetInvoice(id)).Returns(expected);

        var actual = ClassUnderTest.Get(id);

        Assert.AreEqual(expected, actual);

        AutoMocker.Mock<ICodingInterviewDao>().Verify(x => x.GetInvoice(id), Times.Once);
    }

    [TestMethod]
    public void GetInvoice_Throws()
    {
        var id = _random.Next();

        var expected = new TestException();

        AutoMocker.Mock<ICodingInterviewDao>().Setup(x => x.GetInvoice(id)).Throws(expected);

        Assert.ThrowsException<TestException>(() => ClassUnderTest.Get(id));

        AutoMocker.Mock<ICodingInterviewDao>().Verify(x => x.GetInvoice(id), Times.Once);
    }
}
