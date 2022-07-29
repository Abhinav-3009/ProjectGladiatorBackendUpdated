using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectGladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituteController : ControllerBase
    {
        ScholarshipPortalContext db = new ScholarshipPortalContext();
        [HttpPost]
        [Route("AddInstitute")]
        public IActionResult PostInstituteDetails(Institute institute)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Institutes.Add(institute);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Created("Registration successfull", institute);
        }
    }
}
