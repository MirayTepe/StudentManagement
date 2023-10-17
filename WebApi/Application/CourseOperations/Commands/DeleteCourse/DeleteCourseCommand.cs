using WebApi.DBOperations;

namespace WebApi.Application.CourseOperations.Commands.DeleteCourse
{
    public class DeleteCourseCommand{
        
        public int CourseId { get; set; }

        private readonly IStudentManagementDbContext _context;


        public DeleteCourseCommand(IStudentManagementDbContext context)
        {
            _context = context;

        }
        public void Handle()
        {
            var course = _context.Courses.SingleOrDefault(m => m.Id == CourseId);

            if (course is null)
                throw new InvalidOperationException("Silinmek istenen ders bulunamadı!");

            _context.Courses.Remove(course);
            _context.SaveChanges();



        }
    }

}