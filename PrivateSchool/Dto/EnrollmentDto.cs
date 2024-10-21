using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateSchool.Dto
{
    public class EnrollmentDto
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        public required string Semester { get; set; }
    }
}
