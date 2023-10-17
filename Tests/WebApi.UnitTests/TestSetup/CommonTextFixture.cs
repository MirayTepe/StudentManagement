using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
  

        public StudentManagementDbContext Context{get; set;}
        public IMapper  Mapper{get; set;}
         public CommonTestFixture()
        {
            var options=new DbContextOptionsBuilder<StudentManagementDbContext>().UseInMemoryDatabase(databaseName:"StudentManagementTests").Options;
            Context=new StudentManagementDbContext(options);
            Context.Database.EnsureCreated();

            Context.AddCourses();
            Context.AddEnrollments();
            Context.AddTeachers();
            Context.AddStudents();
            Context.SaveChanges();
            

            Mapper=new MapperConfiguration( cfg =>{cfg.AddProfile<MappingProfile>();}).CreateMapper();


        }
    }
}