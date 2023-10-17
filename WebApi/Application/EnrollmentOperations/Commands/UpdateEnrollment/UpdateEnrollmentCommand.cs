using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.EnrollmentOperations.Commands.UpdateEnrollment
{
    public class UpdateEnrollmentCommand{
        
        public int EnrollmentId { get; set; }

        private readonly IStudentManagementDbContext _context;
        
        public UpdateEnrollmentViewModel Model { get; set; }
    
        private readonly IMapper _mapper;


        public UpdateEnrollmentCommand(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var course = _context.Courses.SingleOrDefault(s => s.Id == Model.CourseId);
            var student = _context.Students.SingleOrDefault(s => s.Id == Model.StudentId);
            var enrollment = _context.Enrollments.Include(x=>x.Student).Include(x=>x.Course).SingleOrDefault(s =>s.Id==EnrollmentId );

            if (course is null)
                throw new InvalidOperationException("Ders  kaydı bulunamadı!");
            if (student is null)
                throw new InvalidOperationException("Öğrenci bulunamadı!");
            if (enrollment is null)
                throw new InvalidOperationException("Kayıt bulunamadı!");
           
           
            
            var result = _mapper.Map<Enrollment>(Model);
            result.EnrollmentDate = DateTime.Now;
        

            _context.Enrollments.Add(result);
            _context.SaveChanges();




        }
    }
     public class UpdateEnrollmentViewModel
    {
 
        public int StudentId{get; set;}
        public int CourseId{get; set;}
     
     
    }


}