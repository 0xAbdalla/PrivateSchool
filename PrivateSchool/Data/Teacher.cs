using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace PrivateSchool.Data
{
    public class Teacher
    {
        [Key]

        public int TEID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public required int GradeLevel { get; set; }
        public required string _address { get; set; }

        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
    }
}
