using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.TeacherOperations.Commands.CreateTeacher{
    public class CreateTeacherCommand{
        public CreateTeacherViewModel Model { get; set; }
        private readonly IStudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public CreateTeacherCommand(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
         public void Handle() 
        {
            var teacher = _context.Teachers.SingleOrDefault(s => s.IdentityNumber == Model.IdentityNumber);
           

            if (teacher is not null)
                throw new InvalidOperationException("Bu öğretmenin kaydı daha önce yapılmıştır!");
           

            var result = _mapper.Map<Teacher>(Model);
     

            _context.Teachers.Add(result);
            _context.SaveChanges();
        }
    }

    

    public class CreateTeacherViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }

     
    }
 

}