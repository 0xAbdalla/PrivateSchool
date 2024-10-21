using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace PrivateSchool.Data
{
    public class Payment
    {
        [Key]
        public int PYID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        public required DateTime Payment_Date { get; set; }
        public float total { get; set; }
        public required string Payment_Method { get; set; }
    }
}
