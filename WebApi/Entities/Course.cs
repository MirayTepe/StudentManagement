using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Entities{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TeacherId{get;set;}
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Description { get; set; }
        public Teacher Teacher { get; set; }
        public string Schedule { get; set; }
    }
}