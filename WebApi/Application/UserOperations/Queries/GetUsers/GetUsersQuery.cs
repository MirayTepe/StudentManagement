using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.Quaries
{
    public class GetUserQuery
    {
        private readonly IStudentManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserQuery(IStudentManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<UserViewModel> Handle()
        {
            var users = _dbContext.Users.ToList<User>();
            List<UserViewModel> rg = _mapper.Map<List<UserViewModel>>(users);
            return rg;
        }
    }
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        public string? RefreshToken { get; set; }
    }
}