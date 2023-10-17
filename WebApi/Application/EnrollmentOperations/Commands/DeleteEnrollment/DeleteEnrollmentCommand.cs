using WebApi.DBOperations;

namespace WebApi.Application.EnrollmentOperations.Commands.DeleteEnrollment
{
    public class DeleteEnrollmentCommand{
        
        public int EnrollmentId { get; set; }

        private readonly IStudentManagementDbContext _context;


        public DeleteEnrollmentCommand(IStudentManagementDbContext context)
        {
            _context = context;

        }
        public void Handle()
        {
            var enrollment = _context.Enrollments.SingleOrDefault(m => m.Id == EnrollmentId);

            if (enrollment is null)
                throw new InvalidOperationException("Silinmek istenen kayıt bulunamadı!");

            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();



        }
    }

}