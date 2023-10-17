using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;


namespace WebApi.UnitTests.TestSetup
{
    public static class Students
    {
        public static void AddStudents(this IStudentManagementDbContext context)
        {
           context.Students.AddRange(
                new Student()
                {
                    FirstName = "Ayşe",
                    LastName = "Kaya",
                    IdentityNumber = "11111111111",
                    Class = "A",
                    DateOfBirth = new DateTime(2002, 05, 19),
                    Gender = "Kadın",
                    Email = "ayse@gmail.com",
                    SchoolNumber = "1923",
                    PhoneNumber = "05638233456",



                },
                 new Student()
                 {
                     FirstName = "Bora",
                     LastName = "Kaya",
                     IdentityNumber = "22222222222",
                     Class = "A",
                     DateOfBirth = new DateTime(2000, 08, 28),
                     Gender = "Erkek",
                     Email = "kayabora81@gmail.com",
                     SchoolNumber = "",
                     PhoneNumber = "05658293356",



                 },
                 new Student()
                 {
                     FirstName = "TestFirstName",
                     LastName = "TestLastName",
                     IdentityNumber = "22222222222",
                     Class = "C",
                     DateOfBirth = new DateTime(2000, 10, 28),
                     Gender = "Erkek",
                     Email = "test81@gmail.com",
                     SchoolNumber = "",
                     PhoneNumber = "05658353356",



                 });
        }
    }
}