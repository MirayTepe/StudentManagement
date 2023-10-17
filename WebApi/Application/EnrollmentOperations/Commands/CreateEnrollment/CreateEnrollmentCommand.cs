using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment{
    public class CreateEnrollmentCommand{
        public CreateEnrollmentViewModel Model { get; set; }
        private readonly IStudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public CreateEnrollmentCommand(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
         public void Handle() 
        {
            var course = _context.Courses.SingleOrDefault(s => s.Id == Model.CourseId);
            var student = _context.Students.SingleOrDefault(s => s.Id == Model.StudentId);
            var enrollment = _context.Enrollments.Include(x=>x.Student).Include(x=>x.Course).SingleOrDefault(s =>s.Id == Model.CourseId &&  s.Id == Model.StudentId );

           
            if (course is null)
                throw new InvalidOperationException("Ders  kaydı bulunamadı!");
            if (student is null)
                throw new InvalidOperationException("Öğrenci bulunamadı!");
            if (enrollment is not null)
                throw new InvalidOperationException("Bu kayıt daha önce  yapılmıştır!");
           
            
            var result = _mapper.Map<Enrollment>(Model);
            result.EnrollmentDate = DateTime.Now;
        

            _context.Enrollments.Add(result);
            _context.SaveChanges();
        }
    }

    

    public class CreateEnrollmentViewModel
    {
 
        public int StudentId{get; set;}
        public int CourseId{get; set;}
     
     
    }


    

}