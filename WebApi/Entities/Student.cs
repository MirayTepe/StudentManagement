using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Entities{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string SchoolNumber { get; set; }
        public string Class { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}