using api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class StudentController: Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var path = System.IO.Directory.GetCurrentDirectory();
            //var studentList = new[] {
            //    new { FirstName = "John", LastName = "Doe" },
            //    new { FirstName = path, LastName =path}
            //};
            var studentList2 = new List<Student>();
            using (var db = new DatabaseContext())
            {
                studentList2 = db.Students.ToList();
            }
            return Ok(studentList2);
        }
    }
}
