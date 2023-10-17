using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;


namespace WebApi.UnitTests.TestSetup
{
    public static class Teachers
    {
        public static void AddTeachers(this IStudentManagementDbContext context)
        {
           context.Teachers.AddRange(
                   new Teacher { FirstName = "Ali", LastName = "Deniz", IdentityNumber = "12345678911",PhoneNumber="05426544321",Email="ali@gmail.com",Subject="MATEMATİK" },
                   new Teacher { FirstName = "Ahmet", LastName = "Kara", IdentityNumber = "12445578912",PhoneNumber="05496444331",Email="ali@gmail.com",Subject="TÜRKÇE" },
                   new Teacher { FirstName = "Ayça", LastName = "Doğuş", IdentityNumber = "12336677911",PhoneNumber="05446744621",Email="ayca@gmail.com",Subject="İNGİLİZCE" },
                   new Teacher { FirstName = "Zülfiye", LastName = "Demirci", IdentityNumber = "12045679971",PhoneNumber="05420545021",Email="ali@gmail.com",Subject="TARİH" },
                   new Teacher { FirstName = "ttttttttt", LastName = "eeeeeeeeee", IdentityNumber = "sssssssss",PhoneNumber="05420545021",Email="test@gmail.com",Subject="Tesst" }
               );
        }
    }
}