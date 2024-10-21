using Microsoft.AspNetCore.Mvc;
using private_school.Dto;
using PrivateSchool.Data;
using PrivateSchool.Dto;

namespace Private_School.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // renamed the controller to represent what it does
    public class BoardOfDirectoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;

        public BoardOfDirectoriesController(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // naming convention to follow pascal case
        [HttpPost]
        public IActionResult RegisterBoard([FromBody] BoardOfDirectoryDto BOD)
        {
            try
            {
                var board = new BoardOfDirectory()
                {
                    FirstName = BOD.FirstName,
                    LastName = BOD.LastName,
                    PhoneNumber = BOD.PhoneNumber,
                    Role=BOD.Role,
                    _address = BOD._address,
                    Salary=BOD.Salary
                };
                // Add the BoardOfDirectory to the database
                _appDbContext.BoardOfDirectories.Add(board);
                _appDbContext.SaveChanges();

                return Ok(board.BMID);

                //search for CreatedAtAction if you don't know it, instead of OK
            }
            catch (Exception ex)
            {
                // Handle exceptions and log if necessary
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut]
        public IActionResult editinfo([FromBody] BoardOfDirectory BOD)
        {
            if (BOD == null) // Ensure BoardOfDirectory object is not null
            {
                return BadRequest("BoardOfDirectory data is null.");
            }

            try
            {
                var idboard = _appDbContext.Set<BoardOfDirectory>().Find(BOD.BMID);
                idboard.Role = BOD.Role;
                idboard._address = BOD._address;
                idboard.PhoneNumber = BOD.PhoneNumber;
                idboard.Salary = BOD.Salary;
                _appDbContext.SaveChanges();
                return Ok($"succes to edit the BoardOfDirectory id {BOD.BMID} : {idboard.Role} \t\n==> {idboard._address} \t\n==> {idboard.PhoneNumber} \t\n==> {idboard.Salary}.");

                //search for CreatedAtAction if you don't know it, instead of OK
            }
            catch (Exception ex)
            {
                // Handle exceptions and log if necessary
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete]
        public IActionResult removeboard(int id)
        {
            if (id == 0) // Ensure BoardOfDirectory object is not null
            {
                return BadRequest("BoardOfDirectory data is null.");
            }

            try
            {
                var idboard = _appDbContext.Set<BoardOfDirectory>().Find(id);
                _appDbContext.Set<BoardOfDirectory>().Remove(idboard);
                _appDbContext.SaveChanges();
                return Ok($"succes to remove this BoardOfDirectory.");

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
                var idboard = _appDbContext.Set<BoardOfDirectory>().Find(id);

                return Ok($"my name is {idboard.FirstName} {idboard.LastName} : \n\t ==> and my phone is { idboard.PhoneNumber}\n\t ==> and my addres is {idboard._address}\n\t ==> and my role is {idboard.Role}\n\t ==> and my salary is {idboard.Salary}");

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
