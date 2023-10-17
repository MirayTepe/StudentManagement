using WebApi.DBOperations;

namespace WebApi.Application.StudentOperations.Commands.DeleteStudent
{
    public class DeleteStudentCommand{
        
        public int StudentId { get; set; }

        private readonly IStudentManagementDbContext _context;


        public DeleteStudentCommand(IStudentManagementDbContext context)
        {
            _context = context;

        }
        public void Handle()
        {
            var student = _context.Students.SingleOrDefault(m => m.Id == StudentId);

            if (student is null)
                throw new InvalidOperationException("Silinmek istenen öğrenci bulunamadı!");

            _context.Students.Remove(student);
            _context.SaveChanges();



        }
    }

}