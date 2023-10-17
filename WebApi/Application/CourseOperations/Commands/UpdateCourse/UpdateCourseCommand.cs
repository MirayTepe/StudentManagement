using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CourseOperations.Commands.UpdateCourse{
    public class UpdateCourseCommand{
        public UpdateCourseViewModel Model { get; set; }
        public int CourseId { get; set; }

        private readonly IStudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public UpdateCourseCommand(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var teacher = _context.Teachers.SingleOrDefault(s => s.Id == Model.TeacherId);
            var course = _context.Courses.SingleOrDefault(x => x.Id == CourseId && x.TeacherId==Model.TeacherId);

            if (teacher is null)
                throw new InvalidOperationException("Öğretmen kaydı bulunamadı!");

            if (course is null)
            {
                throw new InvalidOperationException("Ders bulunamadı!");
            }


            _mapper.Map(Model, course);
            
            _context.SaveChanges();
        }
    }
    public class UpdateCourseViewModel
    {
        public int TeacherId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Description { get; set; }
        public string Schedule { get; set; }

     
    }

}