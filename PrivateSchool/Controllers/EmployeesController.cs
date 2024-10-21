using Microsoft.AspNetCore.Mvc;
using private_school.Dto;
using PrivateSchool.Data;
using PrivateSchool.Dto;

namespace Private_School.Controllers
{
        [ApiController]
        [Route("[controller]")]
        // renamed the controller to represent what it does
        public class EmployeesController : ControllerBase
        {
            private readonly ApplicationDbContext _appDbContext;

            public EmployeesController(ApplicationDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }

            // naming convention to follow pascal case
            [HttpPost]
            public IActionResult RegisterEmployee([FromBody] EmployeeDto emp)
            {
                if (emp == null) // Ensure Employee object is not null
                {
                    return BadRequest("Employee data is null.");
                }

                try
                {
                    var employee = new Employee()
                    {
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        _address = emp._address,
                        PhoneNumber = emp.PhoneNumber,
                        _Role = emp._Role,
                        Salary = emp.Salary
                    };
                    // Add the Employee to the database
                    _appDbContext.Employees.Add(employee);
                    _appDbContext.SaveChanges();

                    return Ok(employee.EMID);

                    //search for CreatedAtAction if you don't know it, instead of OK
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log if necessary
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            [HttpPut]
            public IActionResult editinfo([FromBody] Employee emp)
            {
                if (emp == null) // Ensure Employee object is not null
            {
                    return BadRequest("Employee data is null.");
                }

                try
                {
                    var idemployee = _appDbContext.Set<Employee>().Find(emp.EMID);
                    idemployee.Salary = emp.Salary;
                    idemployee._address = emp._address;
                    idemployee.PhoneNumber = emp.PhoneNumber;
                    idemployee._Role = emp._Role;
                    _appDbContext.SaveChanges();
                    return Ok($"succes to edit the Employee id {emp.EMID} : \t\n==> {idemployee.Salary} \t\n==> {idemployee._address} \t\n==> {idemployee.PhoneNumber} \t\n==> {idemployee._Role}.");

                    //search for CreatedAtAction if you don't know it, instead of OK
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log if necessary
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            [HttpDelete]
            public IActionResult removeemployee(int id)
            {
                if (id == 0) // Ensure Employee object is not null
            {
                    return BadRequest("Employee data is null.");
                }

                try
                {
                    var idemployee = _appDbContext.Set<Employee>().Find(id);
                    _appDbContext.Set<Employee>().Remove(idemployee);
                    _appDbContext.SaveChanges();
                    return Ok($"succes to remove this Employee.");

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
                    var idemployee = _appDbContext.Set<Employee>().Find(id);

                    return Ok($"my name is {idemployee.FirstName} {idemployee.LastName}\n\t==> and my phone is {idemployee.PhoneNumber}\n\t==> and my addres is {idemployee._address}\n\t==> and my role is {idemployee._Role}\n\t==> and my salary is {idemployee.Salary}");

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


