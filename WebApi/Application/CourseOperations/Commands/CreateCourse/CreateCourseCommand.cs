using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CourseOperations.Commands.CreateCourse{
    public class CreateCourseCommand{
        public CreateCourseViewModel Model { get; set; }
        private readonly IStudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public CreateCourseCommand(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
         public void Handle() 
        {
            var teacher = _context.Teachers.SingleOrDefault(s => s.Id == Model.TeacherId);
            var course = _context.Courses.SingleOrDefault(s => s.CourseName == Model.CourseName && s.Id == Model.TeacherId);

             if (teacher is null)
                throw new InvalidOperationException("Öğretmen kaydı bulunamadı!");
           

            if (course is not null)
                throw new InvalidOperationException("Bu ders daha önce kaydedildi!");
           

            var result = _mapper.Map<Course>(Model);
     

            _context.Courses.Add(result);
            _context.SaveChanges();
        }
    }

    

    public class CreateCourseViewModel
    {
        public int TeacherId{ get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Description { get; set; }    
        public string Schedule { get; set; }

     
    }


    

}