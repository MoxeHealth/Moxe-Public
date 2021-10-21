using CodingInterview.Databases;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodingInterview.Web
{
    [ApiController]
    [Route("customer")]
    public class CustomerController
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}