namespace CodingInterview.Web;

[ApiController]
[Route("customer")]
public class CustomerController
{
    [HttpGet("{id}")]
    public IActionResult Get(int id) => throw new NotImplementedException();
}
