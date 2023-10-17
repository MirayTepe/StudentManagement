using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.StudentOperations.Queries.GetStudentDetail
{
    public class GetStudentDetailQuery{
        
        public int StudentId { get; set; }

        private readonly IStudentManagementDbContext _context;
    
        private readonly IMapper _mapper;


        public GetStudentDetailQuery(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetStudentDetailViewModel Handle()
        {
           
            var student = _context.Students.SingleOrDefault(s=>s.Id==StudentId);
            
            if (student is  null)
                throw new InvalidOperationException("Bu öğrenci kaydı bulunamadı!");
           

            GetStudentDetailViewModel vm = _mapper.Map<GetStudentDetailViewModel>(student);

            return vm;
        }
    }
     
    public class GetStudentDetailViewModel
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