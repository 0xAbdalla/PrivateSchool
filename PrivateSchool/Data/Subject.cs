using System.ComponentModel.DataAnnotations;

namespace PrivateSchool.Data
{
    public class Subject
    {
        [Key]
        public int SUID { get; set; }
        public required string SubjectName { get; set; }
        public required string GradeLevel { get; set; }
        public required int credits { get; set; }
    }
}
