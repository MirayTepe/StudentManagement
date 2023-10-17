using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.TeacherOperations.Commands.UpdateTeacher{
    public class UpdateTeacherCommand{
        public UpdateTeacherViewModel Model { get; set; }
        public int TeacherId { get; set; }

        private readonly IStudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public UpdateTeacherCommand(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var teacher = _context.Teachers.SingleOrDefault(x => x.Id == TeacherId);

            if (teacher is null)
            {
                throw new InvalidOperationException("Öğretmen bulunamadı!");
            }


            _mapper.Map(Model, teacher);

           
            _context.SaveChanges();
        }
    }
    public class UpdateTeacherViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }

     
    }

}