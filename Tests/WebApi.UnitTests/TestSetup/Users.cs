using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;


namespace WebApi.UnitTests.TestSetup
{
    public static class Users
    {
        public static void AddUser(this IStudentManagementDbContext context)
        {
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
        }
    }
}