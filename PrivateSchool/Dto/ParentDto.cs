using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateSchool.Dto
{
    public class ParentDto
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
