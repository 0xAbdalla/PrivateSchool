namespace PrivateSchool.Dto
{
    public class EmployeeDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string _Role { get; set; }
        public required string _address { get; set; }
        public required float Salary { get; set; }
    }
}
