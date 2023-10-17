using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.StudentOperations.Commands.UpdateStudent{
    public class UpdateStudentCommand{
        public UpdateStudentViewModel Model { get; set; }
        public int StudentId { get; set; }

        private readonly IStudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public UpdateStudentCommand(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == StudentId);

            if (student is null)
            {
                throw new InvalidOperationException("Öğrenci bulunamadı!");
            }


             _mapper.Map(Model, student);
            
           
            _context.SaveChanges();
        }
    }
    public class UpdateStudentViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string SchoolNumber { get; set; }
        public string Class { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

     
    }

}