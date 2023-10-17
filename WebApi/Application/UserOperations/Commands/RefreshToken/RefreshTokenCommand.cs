using WebApi.DBOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IStudentManagementDbContext _context;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IStudentManagementDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x=>x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate>DateTime.Now);
            if (user is not null)
            {
                TokenHandler tokenHandler = new(_configuration);
                Token token = tokenHandler.CreateAccesToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            else
                throw new InvalidOperationException("Geçerli bir RefreshToken bulunamadı !");
        }
    }
}