using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class StudentController: Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var result = new[] {
                new { FirstName = "John", LastName = "Doe" },
                new { FirstName = "Mike", LastName = "Smith" }
            };

            return Ok(result);
        }
    }
}
