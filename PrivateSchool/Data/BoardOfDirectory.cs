using System.ComponentModel.DataAnnotations;

namespace PrivateSchool.Data
{
    public class BoardOfDirectory
    {
        [Key]
        public int BMID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Role { get; set; }
        public required string _address { get; set; }
        public required float Salary { get; set; }
    }
}
