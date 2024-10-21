using Microsoft.AspNetCore.Mvc;
using private_school.Dto;
using PrivateSchool.Data;
using PrivateSchool.Dto;
using PrivateSchool.Migrations;

namespace Private_School.Controllers
{
        [ApiController]
        [Route("[controller]")]
        // renamed the controller to represent what it does
        public class SubjectsController : ControllerBase
        {
            private readonly ApplicationDbContext _appDbContext;

            public SubjectsController(ApplicationDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }

            // naming convention to follow pascal case
            [HttpPost]
            public IActionResult RegisterSubject([FromBody] SubjectDto sub)
            {
                if (sub == null) // Ensure Subject object is not null
                {
                    return BadRequest("Subject data is null.");
                }

                try
                {
                    var subject = new Subject()
                    {
                        SubjectName = sub.SubjectName,
                        GradeLevel = sub.GradeLevel,
                        credits = sub.credits
                    };
                    // Add the student to the database
                    _appDbContext.Subjects.Add(subject);
                    _appDbContext.SaveChanges();

                    return Ok(subject.SUID);

                    //search for CreatedAtAction if you don't know it, instead of OK
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log if necessary
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            [HttpPut]
            public IActionResult editinfo([FromBody] Subject sub)
            {
                if (sub == null) // Ensure Subject object is not null
            {
                    return BadRequest("Subject data is null.");
                }

                try
                {
                    var idsubject = _appDbContext.Set<Subject>().Find(sub.SUID);
                    idsubject.GradeLevel = sub.GradeLevel;
                    idsubject.SubjectName = sub.SubjectName;
                    _appDbContext.SaveChanges();
                    return Ok($"succes to edit the Subject id {sub.SUID} : \t\n==> {idsubject.GradeLevel} \t\n==> {idsubject.SubjectName}.");

                    //search for CreatedAtAction if you don't know it, instead of OK
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log if necessary
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            [HttpDelete]
            public IActionResult removesubject(int id)
            {
                if (id == 0) // Ensure subject object is not null
                {
                    return BadRequest("subject data is null.");
                }

                try
                {
                    var idsubject = _appDbContext.Set<Subject>().Find(id);
                    _appDbContext.Set<Subject>().Remove(idsubject);
                    _appDbContext.SaveChanges();
                    return Ok($"succes to remove this Subject.");

                    //search for CreatedAtAction if you don't know it, instead of OK
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log if necessary
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpGet]
            public IActionResult inquiryofnumbercredits(int id)
            {

               try
               {
                var idsubject = _appDbContext.Set<Subject>().Find(id);
                  var numsubject = _appDbContext.Set<Enrollment>().ToList();
                  int count = 0;
                  for (int i = 0; i < numsubject.LongCount(); i++)
                  {
                    if (numsubject[i].SubjectID == id)
                    {
                        count++;
                    }

                  }
                  return Ok($"number of credits to {idsubject.SubjectName} is {count}.");
               }
               catch (Exception ex)
               {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
               }
            }
        }

}
