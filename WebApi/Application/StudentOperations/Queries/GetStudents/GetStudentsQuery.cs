using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.StudentOperations.Queries.GetStudents{
    public class GetStudentsQuery{

        private readonly IStudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public GetStudentsQuery(IStudentManagementDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetStudentsViewModel> Handle()
        {
            List<Student> students = _context.Students.OrderBy(x => x.Id).ToList();                   
        
            
            List<GetStudentsViewModel> vm = _mapper.Map<List<GetStudentsViewModel>>(students);

            return vm;
        }
    }

    public class GetStudentsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string SchoolNumber { get; set; }
        public string Class { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

     
     
    }
}