using Microsoft.AspNetCore.Mvc;
using private_school.Dto;
using PrivateSchool.Data;
using PrivateSchool.Dto;

namespace Private_School.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // renamed the controller to represent what it does
    public class ParentsController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;

        public ParentsController(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpPost]
        public IActionResult RegisterParent([FromBody] ParentDto prnt)
        {
            if (prnt == null) // Ensure parent object is not null
            {
                return BadRequest("parent data is null.");
            }

            try
            {
                var parent = new Parent()
                {
                    StudentID = prnt.StudentID,
                    FirstName = prnt.FirstName,
                    LastName = prnt.LastName,
                    PhoneNumber = prnt.PhoneNumber
                };
                // Add the parent to the database
                _appDbContext.Parents.Add(parent);
                _appDbContext.SaveChanges();

                return Ok(parent.PAID);

                //search for CreatedAtAction if you don't know it, instead of OK
            }
            catch (Exception ex)
            {
                // Handle exceptions and log if necessary
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut]
        public IActionResult editinfo([FromBody] Parent prnt)
        {
            if (prnt == null) // Ensure parent object is not null
            {
                return BadRequest("parent data is null.");
            }

            try
            {
                var idparent = _appDbContext.Set<Parent>().Find(prnt.PAID);
                idparent.PhoneNumber = prnt.PhoneNumber;
                idparent.StudentID = prnt.StudentID;
                _appDbContext.SaveChanges();
                return Ok($"succes to edit the parent id {prnt.PAID} : \t\n==> {idparent.PhoneNumber} \t\n==> {idparent.StudentID}.");

                //search for CreatedAtAction if you don't know it, instead of OK
            }
            catch (Exception ex)
            {
                // Handle exceptions and log if necessary
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete]
        public IActionResult removeparent(int id)
        {
            if (id == 0) // Ensure parent object is not null
            {
                return BadRequest("parent data is null.");
            }

            try
            {
                var idparent = _appDbContext.Set<Parent>().Find(id);
                _appDbContext.Set<Parent>().Remove(idparent);
                _appDbContext.SaveChanges();
                return Ok($"succes to remove this parent.");

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
                var idparent = _appDbContext.Set<Parent>().Find(id);

                return Ok($"my name is {idparent.FirstName} {idparent.LastName}\n\t==> and my phone is {idparent.PhoneNumber}\n\t==> and id of son {idparent.StudentID}");

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