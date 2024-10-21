using Microsoft.AspNetCore.Mvc;
using private_school.Dto;
using PrivateSchool.Data;
using PrivateSchool.Dto;

namespace Private_School.Controllers
{
        [ApiController]
        [Route("[controller]")]
        // renamed the controller to represent what it does
        public class PaymentsController : ControllerBase
        {
            private readonly ApplicationDbContext _appDbContext;

            public PaymentsController(ApplicationDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }

            // naming convention to follow pascal case
            [HttpPost]
            public IActionResult Registerpayment([FromBody] PaymentDto pay)
            {
                if (pay == null) // Ensure Payment object is not null
                {
                    return BadRequest("Payment data is null.");
                }

                try
                {
                    var payment = new Payment()
                    {
                        StudentID = pay.StudentID,
                        SubjectID = pay.SubjectID,
                        Payment_Date = pay.Payment_Date,
                        Payment_Method = pay.Payment_Method,
                    };
                    // Add the Payment to the database
                    _appDbContext.Payments.Add(payment);
                    payment.total = payment.StudentID + 10;
                    _appDbContext.SaveChanges();

                    return Ok(payment.PYID);

                    //search for CreatedAtAction if you don't know it, instead of OK
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log if necessary
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            [HttpPut]
            public IActionResult editinprocesspayment([FromBody] Payment pay)
            {
                if (pay == null) // Ensure Payment object is not null
            {
                    return BadRequest("Payment data is null.");
                }

                try
                {
                    var idpayment = _appDbContext.Set<Payment>().Find(pay.PYID);
                    idpayment.StudentID = pay.StudentID;
                    idpayment.SubjectID = pay.SubjectID;
                    idpayment.Payment_Method = pay.Payment_Method;
                    _appDbContext.SaveChanges();
                    return Ok($"succes to edit the Payment id {pay.PYID} : \t\n==> {idpayment.StudentID} \t\n==> {idpayment.SubjectID} \t\n==> {idpayment.Payment_Method}.");

                    //search for CreatedAtAction if you don't know it, instead of OK
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log if necessary
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            [HttpDelete]
            public IActionResult removepayment(int id)
            {
                if (id == 0) // Ensure Payment object is not null
            {
                    return BadRequest("Payment data is null.");
                }

                try
                {
                    var idpayment = _appDbContext.Set<Payment>().Find(id);
                    _appDbContext.Set<Payment>().Remove(idpayment);
                    _appDbContext.SaveChanges();
                    return Ok($"succes to remove this Payment.");

                    //search for CreatedAtAction if you don't know it, instead of OK
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log if necessary
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpGet]
            public IActionResult inquiryabouttotalpaymeny(int id)
            {

                try
                {
                    var idpayment = _appDbContext.Set<Payment>().Find(id);
                    return Ok($"The total of process payment is : {idpayment.total}.");
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
