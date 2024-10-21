using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateSchool.Dto
{
    public class TeacherDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public required int GradeLevel { get; set; }
        public required string _address { get; set; }

        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
    }
}
