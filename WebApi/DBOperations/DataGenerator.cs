using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentManagementDbContext(
           serviceProvider.GetRequiredService<DbContextOptions<StudentManagementDbContext>>()))
            {
                // Look for any book.
                if (context.Students.Any())
                {
                    return;   // Data was already seeded
                }

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



                 });
                context.Courses.AddRange(
                   new Course { CourseName = "MATEMATİK", TeacherId = 1, CourseCode = "MAT101" },
                   new Course { CourseName = "TÜRKÇE", TeacherId = 2, CourseCode = "TUR101" },
                   new Course { CourseName = "İNGİLİZCE", TeacherId = 3, CourseCode = "ENG101" },
                   new Course { CourseName = "TARİH", TeacherId = 4, CourseCode = "TAR101" }
               );
               context.Teachers.AddRange(
                   new Teacher { FirstName = "Ali", LastName = "Deniz", IdentityNumber = "12345678911",PhoneNumber="05426544321",Email="ali@gmail.com",Subject="MATEMATİK" },
                   new Teacher { FirstName = "Ahmet", LastName = "Kara", IdentityNumber = "12445578912",PhoneNumber="05496444331",Email="ali@gmail.com",Subject="TÜRKÇE" },
                   new Teacher { FirstName = "Ayça", LastName = "Doğuş", IdentityNumber = "12336677911",PhoneNumber="05446744621",Email="ayca@gmail.com",Subject="İNGİLİZCE" },
                   new Teacher { FirstName = "Zülfiye", LastName = "Demirci", IdentityNumber = "12045679971",PhoneNumber="05420545021",Email="ali@gmail.com",Subject="TARİH" }
               );
               context.Users.AddRange(
                    new User
                    {
                        FirstName = "Ayşe",
                        LastName = "Taş",
                        Email = "ayse95@gmail.com",
                        Password = "123456"

                    },
                    new User
                    {
                        FirstName = "fatma",
                        LastName = "Kaya",
                        Email = "kaya@gmail.com",
                        Password = "123456"

                    },
                    new User
                    {
                        FirstName = "Demir",
                        LastName = "Yıldırım",
                        Email = "demir@gmail.com",
                        Password = "123456"

                    }
                );
                context.Enrollments.AddRange(
                    new Enrollment
                    {
                        StudentId=1,
                        CourseId=1,
                    },
                    new Enrollment
                    {
                        StudentId=1,
                        CourseId=2 

                    },
                    new Enrollment
                    {
                        StudentId=2,
                        CourseId=1 

                    },
                    new Enrollment
                    {
                        StudentId=2,
                        CourseId=2 

                    }
                     

                );




                context.SaveChanges();
            }

        }
    }
}