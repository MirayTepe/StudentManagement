using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.TeacherOperations.Queries.GetTeacherDetail
{
    public class GetTeacherDetailQuery{
        
        public int TeacherId { get; set; }

        private readonly IStudentManagementDbContext _context;
    
        private readonly IMapper _mapper;


        public GetTeacherDetailQuery(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetTeacherDetailViewModel Handle()
        {
           
            var teacher = _context.Teachers.SingleOrDefault(s=>s.Id==TeacherId);
            
            if (teacher is  null)
                throw new InvalidOperationException("Bu öğretmenin kaydı bulunamadı!");
           

            GetTeacherDetailViewModel vm = _mapper.Map<GetTeacherDetailViewModel>(teacher);

            return vm;
        }
    }
     
    public class GetTeacherDetailViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }

     
     
    }


}