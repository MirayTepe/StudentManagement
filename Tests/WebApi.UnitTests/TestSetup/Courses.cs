using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;


namespace WebApi.UnitTests.TestSetup
{
    public static class Courses
    {
        public static void AddCourses(this IStudentManagementDbContext context)
        {
           context.Courses.AddRange(
                   new Course { CourseName = "MATEMATİK", TeacherId = 1, CourseCode = "MAT101" ,Description="D-103'de yapılacak.",Schedule="Salı 8:30"},
                   new Course { CourseName = "TÜRKÇE", TeacherId = 2, CourseCode = "TUR101",Description="D-105'de yapılacak.",Schedule="Salı 13:30" },
                   new Course { CourseName = "İNGİLİZCE", TeacherId = 3, CourseCode = "ENG101",Description="D-202'de yapılacak.",Schedule="Çalışma 8:30" },
                   new Course { CourseName = "TARİH", TeacherId = 4, CourseCode = "TAR101",Description="D-303'de yapılacak.",Schedule="Perşembe 15:30" },
                   new Course { CourseName = "TEST", TeacherId = 4, CourseCode = "TEST101",Description="D-306'de yapılacak.",Schedule="Perşembe 8:30" }
            );
        }
    }
}