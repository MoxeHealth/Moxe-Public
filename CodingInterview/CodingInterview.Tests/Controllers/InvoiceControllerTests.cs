namespace CodingInterview.Tests;

[TestClass]
public class InvoiceControllerTests : MockingTestBase<InvoiceController>
{
    private readonly Random _random = new();

    [TestMethod]
    public void Get_Ok()
    {
        var id = _random.Next();

        AutoMocker.Mock<IInvoiceService>().Setup(x => x.Get(id)).Returns(new Invoice());

        var actual = ClassUnderTest.Get(id);

        var okObjectResultObject = actual as OkObjectResult;
        Assert.IsNotNull(okObjectResultObject);
        Assert.AreEqual(200, okObjectResultObject.StatusCode);
        AutoMocker.Mock<IInvoiceService>().Verify(x => x.Get(id), Times.Once);
    }

    [TestMethod]
    public void Get_NotFound()
    {
        var id = _random.Next();

        AutoMocker.Mock<IInvoiceService>().Setup(x => x.Get(id)).Returns(default(Invoice));

        var actual = ClassUnderTest.Get(id);

        var notFoundResultObject = actual as NotFoundResult;
        Assert.IsNotNull(notFoundResultObject);
        Assert.AreEqual(404, notFoundResultObject.StatusCode);
        AutoMocker.Mock<IInvoiceService>().Verify(x => x.Get(id), Times.Once);
    }

    [TestMethod]
    public void GetByCustomerId()
    {
        var id = _random.Next();

        Assert.ThrowsException<NotImplementedException>(() => ClassUnderTest.GetByCustomerId(id));
    }
}