using CodingInterview.Databases;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodingInterview.Web;

[ApiController]
[Route("item")]
public class ItemController
{
    [HttpGet("{id}")]
    public IActionResult Get(int id) => throw new NotImplementedException();
}
