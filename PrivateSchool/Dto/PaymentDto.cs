using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateSchool.Dto
{
    public class PaymentDto
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        public required DateTime Payment_Date { get; set; }
        public required float total { get; set; }
        public required string Payment_Method { get; set; }
    }
}
