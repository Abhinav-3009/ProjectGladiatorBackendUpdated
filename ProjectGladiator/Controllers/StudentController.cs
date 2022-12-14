using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectGladiator.Models;
using ProjectGladiator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        ScholarshipPortalContext db = new ScholarshipPortalContext();
        [HttpGet]
        [Route("StudentDetails")]
        public IActionResult GetStudentDetails()
        {
            var data = from d in db.Students select d;
            return Ok(data);
        }
        [HttpGet]
        [Route("StudentDetails/{id}")]
        public IActionResult GetStudentDetails(int? id)
        {
            if (id == null)
            {
                return BadRequest("id cannot be null");
            }
            var data = (from d in db.Students where d.StudentId == id select d).FirstOrDefault();
            if (data == null)
            {
                return NotFound($"Student {id} not present");
            }
            return Ok(data);
        }
        [HttpPost]
        [Route("AddStudent")]
        public IActionResult PostStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Created("Record successfully added", student);
        }
        [HttpPost]
        [Route("StudentLogin")]
        public IActionResult PostStudentLogin(StudentLogin login)
        {
            var data = db.Students.ToList();
            var student = (from d in data where d.Aadhaar == login.Aadhaar && d.Password == login.Password select d).FirstOrDefault();

            if (student == null)
                return BadRequest("Username or Password is Incorrect");
            return Ok(student);
        }
    }
}
