using Microsoft.AspNetCore.Mvc;
using private_school.Dto;
using PrivateSchool.Data;
using PrivateSchool.Dto;

namespace Private_School.Controllers
{
        [ApiController]
        [Route("[controller]")]
        // renamed the controller to represent what it does
        public class EnrollmentsController : ControllerBase
        {
            private readonly ApplicationDbContext _appDbContext;

            public EnrollmentsController(ApplicationDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }

            // naming convention to follow pascal case
            [HttpPost]
            public IActionResult processenrollment([FromBody] EnrollmentDto enr)
            {
                if (enr == null) // Ensure Enrollment object is not null
                {
                    return BadRequest("Enrollment data is null.");
                }

                try
                {
                    var enrollment = new Enrollment()
                    {
                        StudentID = enr.StudentID,
                        SubjectID = enr.SubjectID,
                        Semester = enr.Semester
                    };
                    // Add the Enrollment to the database
                    _appDbContext.Enrollments.Add(enrollment);
                    _appDbContext.SaveChanges();

                    return Ok(enrollment.ENID);

                    //search for CreatedAtAction if you don't know it, instead of OK
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log if necessary
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            [HttpPut]
            public IActionResult editenrollment([FromBody] Enrollment enr)
            {
                if (enr == null) // Ensure Enrollment object is not null
            {
                    return BadRequest("Enrollment data is null.");
                }

                try
                {
                    var idenrollment = _appDbContext.Set<Enrollment>().Find(enr.ENID);
                    idenrollment.Semester = enr.Semester;
                    idenrollment.StudentID = enr.StudentID;
                    idenrollment.SubjectID = enr.StudentID;
                    _appDbContext.SaveChanges();
                    return Ok($"succes to edit the Enrollment id {enr.ENID} : \t\n==> {idenrollment.Semester} \t\n==> {idenrollment.SubjectID} \t\n==> {idenrollment.StudentID}.");

                    //search for CreatedAtAction if you don't know it, instead of OK
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log if necessary
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            [HttpDelete]
            public IActionResult removeenrollment(int id)
            {
                if (id == 0) // Ensure Enrollment object is not null
            {
                    return BadRequest("Enrollment data is null.");
                }

                try
                {
                    var idenrollment = _appDbContext.Set<Enrollment>().Find(id);
                    _appDbContext.Set<Enrollment>().Remove(idenrollment);
                    _appDbContext.SaveChanges();
                    return Ok($"succes to remove this Enrollment.");

                    //search for CreatedAtAction if you don't know it, instead of OK
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log if necessary
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpGet]
            public IActionResult inquiryaboutofenrollment(int id)
            {

                try
                {
                    var idenrollment = _appDbContext.Set<Enrollment>().Find(id);
                    return Ok($"This enrollment id {idenrollment.ENID} :\n\t==>to the student id {idenrollment.StudentID}\n\t==>to subject id {idenrollment.SubjectID}\n\t==>to semester {idenrollment.Semester}.");
                    //search for CreatedAtAction if you don't know it, instead of OK
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log if necessary
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }

}
