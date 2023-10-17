using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public interface IStudentManagementDbContext
    {
        DbSet<Course> Courses{get;set;}
        DbSet<Enrollment> Enrollments{get;set;}
        DbSet<Student> Students{get;set;}
        DbSet<Teacher> Teachers{get;set;}
        DbSet<User> Users{get;set;}
        int SaveChanges();
    } 
}