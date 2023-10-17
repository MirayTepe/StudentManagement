using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CourseOperations.Commands.GetEnrollments{
    public class GetEnrollmentsQuery{

        private readonly IStudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public GetEnrollmentsQuery(IStudentManagementDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetEnrolmentsViewModel> Handle()
        {
            List<Enrollment> enrollments = _context.Enrollments.Include(q=>q.Course).Include(q=>q.Student).OrderBy(x => x.Id).ToList();                   
        
            
            List<GetEnrolmentsViewModel> vm = _mapper.Map<List<GetEnrolmentsViewModel>>(enrollments);

            return vm;
        }
    }

    public class GetEnrolmentsViewModel
    {
        public string Course{get;set;}
        public string Student{get;set;}
        public DateTime EnrollmentDate{get; set;}

     
    }
    
}