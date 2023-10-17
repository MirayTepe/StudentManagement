using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.TeacherOperations.Queries.GetTeachers{
    public class GetTeachersQuery{

        private readonly IStudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public GetTeachersQuery(IStudentManagementDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetTeachersViewModel> Handle()
        {
            List<Teacher> teachers = _context.Teachers.OrderBy(x => x.Id).ToList();                   
        
            
            List<GetTeachersViewModel> vm = _mapper.Map<List<GetTeachersViewModel>>(teachers);

            return vm;
        }
    }

    public class GetTeachersViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
     
     
    }
}