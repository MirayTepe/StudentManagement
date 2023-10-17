using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class StudentManagementDbContext : DbContext, IStudentManagementDbContext
    {
        public StudentManagementDbContext(DbContextOptions<StudentManagementDbContext> options):base(options)
        {
        }

        public DbSet<Course> Courses { get; set ; }
        public DbSet<Enrollment> Enrollments { get; set ; }
        public DbSet<Student> Students { get; set ; }
        public DbSet<Teacher> Teachers { get; set ; }
        public DbSet<User> Users { get; set ; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}