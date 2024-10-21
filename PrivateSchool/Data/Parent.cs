using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace PrivateSchool.Data
{
    public class Parent
    {
        [Key]

        public int PAID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
