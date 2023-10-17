using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CourseOperations.Commands.GetCourseDetail{
    public class GetCourseDetailQuery{

        private readonly IStudentManagementDbContext _context;
        private readonly IMapper _mapper;
        public int CourseId { get; set; }

        public GetCourseDetailQuery(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetCourseDetailViewModel Handle()
        {
            var course = _context.Courses.Include(x=>x.Teacher).SingleOrDefault(s=>s.Id==CourseId);
                    
             if (course is  null)
                throw new InvalidOperationException("Bu dersin kaydı bulunamadı!");                   
        
            
            GetCourseDetailViewModel vm = _mapper.Map<GetCourseDetailViewModel>(course);

            return vm;

        }
    }

    public class GetCourseDetailViewModel
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Description { get; set; }
        public string Teacher { get; set; }
        public string Schedule { get; set; }

     
    }
    
}