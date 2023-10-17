using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.StudentOperations.Commands.CreateStudent{
    public class CreateStudentCommand{
        public CreateStudentViewModel Model { get; set; }
        private readonly IStudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public CreateStudentCommand(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
         public void Handle() 
        {
            var student = _context.Students.SingleOrDefault(s => s.SchoolNumber == Model.SchoolNumber);
           

            if (student is not null)
                throw new InvalidOperationException("Bu öğrencinin kaydı daha önce yapılmıştır!");
           

            var result = _mapper.Map<Student>(Model);
     

            _context.Students.Add(result);
            _context.SaveChanges();
        }
    }

    

    public class CreateStudentViewModel
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