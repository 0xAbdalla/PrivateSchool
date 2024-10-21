using Microsoft.AspNetCore.Mvc;
using private_school.Dto;
using PrivateSchool.Data;

namespace Private_School.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // renamed the controller to represent what it does
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;

        public StudentsController(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // naming convention to follow pascal case
        [HttpPost]
        public IActionResult RegisterStudent([FromBody] StudentDto stu)
        {
            if (stu == null) // Ensure student object is not null
            {
                return BadRequest("Student data is null.");
            }

            try
            {
                var student = new Student()
                {
                    DateOfBirth = stu.DateOfBirth,
                    FirstName = stu.FirstName,
                    _address = stu._address,
                    GradeLevel = stu.GradeLevel,
                    LastName = stu.LastName,
                    PhoneNumber = stu.PhoneNumber
                };
                // Add the student to the database
                _appDbContext.Students.Add(student);
                _appDbContext.SaveChanges();

                return Ok(student.Id);

                //search for CreatedAtAction if you don't know it, instead of OK
            }
            catch (Exception ex)
            {
                // Handle exceptions and log if necessary
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut]
        public IActionResult editinfo([FromBody]Student stu) 
        {
            if (stu == null) // Ensure student object is not null
            {
                return BadRequest("Student data is null.");
            }

            try
            {
                var idstudent = _appDbContext.Set<Student>().Find(stu.Id);
                idstudent.GradeLevel = stu.GradeLevel;
                idstudent._address = stu._address;
                idstudent.PhoneNumber = stu.PhoneNumber;
                _appDbContext.SaveChanges();
                return Ok($"succes to edit the student id {stu.Id} : \t\n==> {idstudent.GradeLevel} \t\n==> {idstudent._address} \t\n==> {idstudent.PhoneNumber}.");

                //search for CreatedAtAction if you don't know it, instead of OK
            }
            catch (Exception ex)
            {
                // Handle exceptions and log if necessary
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete]
        public IActionResult removestudent(int id)
        {
            if (id == 0) // Ensure student object is not null
            {
                return BadRequest("Student data is null.");
            }

            try
            {
                var idstudent = _appDbContext.Set<Student>().Find(id);
                _appDbContext.Set<Student>().Remove(idstudent);
                _appDbContext.SaveChanges();
                return Ok($"succes to remove this student.");

                //search for CreatedAtAction if you don't know it, instead of OK
            }
            catch (Exception ex)
            {
                // Handle exceptions and log if necessary
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult inquirymyinfo(int id)
        {

            try
            {
                var idstudent = _appDbContext.Set<Student>().Find(id);

                return Ok($"my name is {idstudent.FirstName} {idstudent.LastName} \t\n==> and my phone is {idstudent.PhoneNumber}\n\t==> and my addres is {idstudent._address}\n\t==> and my grade level is {idstudent.GradeLevel}\n\t==> and my date of birth {idstudent.DateOfBirth}");

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
