using Microsoft.EntityFrameworkCore;

namespace PrivateSchool.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<BoardOfDirectory> BoardOfDirectories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


    }
}
