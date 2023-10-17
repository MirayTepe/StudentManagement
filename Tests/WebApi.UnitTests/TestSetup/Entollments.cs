using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;


namespace WebApi.UnitTests.TestSetup
{
    public static class Enrollments
    {
        public static void AddEnrollments(this IStudentManagementDbContext context)
        {
           context.Enrollments.AddRange(
                    new Enrollment {CourseId = 1, StudentId = 1 },
                    new Enrollment {CourseId = 2, StudentId = 1 },
                    new Enrollment {CourseId = 3, StudentId = 1 },
                    new Enrollment {CourseId = 4, StudentId = 1 },
                    new Enrollment {CourseId = 1, StudentId = 2 },
                    new Enrollment {CourseId = 2, StudentId = 2 },
                    new Enrollment {CourseId = 3, StudentId = 2 },
                    new Enrollment {CourseId = 4, StudentId = 2 }
                  
            );
        }
    }
}