using Microsoft.AspNetCore.Mvc;
using private_school.Dto;
using PrivateSchool.Data;
using PrivateSchool.Dto;

namespace Private_School.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // renamed the controller to represent what it does
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;

        public TeachersController(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // naming convention to follow pascal case
        [HttpPost]
        public IActionResult RegisterTeacher([FromBody] TeacherDto tea)
        {
            if (tea == null) // Ensure Teacher object is not null
            {
                return BadRequest("Teacher data is null.");
            }

            try
            {
                var teacher = new Teacher()
                {
                    FirstName = tea.FirstName,
                    LastName = tea.LastName,
                    _address = tea._address,
                    PhoneNumber = tea.PhoneNumber,
                    GradeLevel = tea.GradeLevel,
                    SubjectID = tea.SubjectID
                };
                // Add the Teacher to the database
                _appDbContext.Teachers.Add(teacher);
                _appDbContext.SaveChanges();

                return Ok(teacher.TEID);

                //search for CreatedAtAction if you don't know it, instead of OK
            }
            catch (Exception ex)
            {
                // Handle exceptions and log if necessary
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut]
        public IActionResult editinfo([FromBody] Teacher tea)
        {
            if (tea == null) // Ensure Teacher object is not null
            {
                return BadRequest("Teacher data is null.");
            }

            try
            {
                var idteacher = _appDbContext.Set<Teacher>().Find(tea.TEID);
                idteacher.GradeLevel = tea.GradeLevel;
                idteacher._address = tea._address;
                idteacher.PhoneNumber = tea.PhoneNumber;
                _appDbContext.SaveChanges();
                return Ok($"succes to edit the Teacher id {tea.TEID} : \t\n==> {idteacher.GradeLevel} \t\n==> {idteacher._address} \t\n==> {idteacher.PhoneNumber}.");

                //search for CreatedAtAction if you don't know it, instead of OK
            }
            catch (Exception ex)
            {
                // Handle exceptions and log if necessary
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete]
        public IActionResult removeteacher(int id)
        {
            if (id == 0) // Ensure Teacher object is not null
            {
                return BadRequest("Teacher data is null.");
            }

            try
            {
                var idteacher = _appDbContext.Set<Teacher>().Find(id);
                _appDbContext.Set<Teacher>().Remove(idteacher);
                _appDbContext.SaveChanges();
                return Ok($"succes to remove this Teacher.");

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
                var idteacher = _appDbContext.Set<Teacher>().Find(id);

                return Ok($"my name is {idteacher.FirstName} {idteacher.LastName}\n\t==> and my phone is {idteacher.PhoneNumber}\n\t==> and my addres is {idteacher._address}\n\t==> and my grade level is {idteacher.GradeLevel}\n\t==> and my subject id is {idteacher.SubjectID}");

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
