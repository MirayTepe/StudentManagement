using WebApi.DBOperations;

namespace WebApi.Application.TeacherOperations.Commands.DeleteTeacher
{
    public class DeleteTeacherCommand{
        
        public int TeacherId { get; set; }

        private readonly IStudentManagementDbContext _context;


        public DeleteTeacherCommand(IStudentManagementDbContext context)
        {
            _context = context;

        }
        public void Handle()
        {
            var teacher = _context.Teachers.SingleOrDefault(m => m.Id == TeacherId);

            if (teacher is null)
                throw new InvalidOperationException("Silinmek istenen öğretmen bulunamadı!");

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();



        }
    }

}