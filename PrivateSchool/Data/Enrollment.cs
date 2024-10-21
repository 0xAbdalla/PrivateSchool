using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace PrivateSchool.Data
{
    public class Enrollment
    {
        [Key]

        public int ENID { get; set; }
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        public required string Semester { get; set; }

    }
}
