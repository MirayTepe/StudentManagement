using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CourseOperations.Commands.GetCourses{
    public class GetCoursesQuery{

        private readonly IStudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public GetCoursesQuery(IStudentManagementDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetCoursesViewModel> Handle()
        {
            List<Course> course = _context.Courses.Include(c=>c.Teacher).OrderBy(x => x.Id).ToList();                   
        
            
            List<GetCoursesViewModel> vm = _mapper.Map<List<GetCoursesViewModel>>(course);

            return vm;
        }
    }

    public class GetCoursesViewModel
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Description { get; set; }
        public string Teacher { get; set; }
        public string Schedule { get; set; }

     
    }
    
}