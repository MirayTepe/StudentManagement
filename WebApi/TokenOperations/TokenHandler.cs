using WebApi.Entities;
using WebApi.TokenOperations.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace  WebApi.TokenOperations
{
    public class TokenHandler
    {
        private readonly IConfiguration Configuration;

        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Token CreateAccesToken(User user)
        {
            Token tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials (key, SecurityAlgorithms.HmacSha256);

            tokenModel.Expiration = DateTime.Now.AddMinutes(15);
            JwtSecurityToken securityToken = new JwtSecurityToken(
            issuer: Configuration["Token:Issuer"],
            audience: Configuration["Token:Audience"],
            expires: tokenModel.Expiration,
            notBefore: DateTime.Now,
            signingCredentials: signingCredentials);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //tpken yaratılıyor
            tokenModel.AccessToken= tokenHandler.WriteToken( securityToken );
            tokenModel.RefreshToken = CreateRefreshToken();
            return tokenModel;
        }
        private string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();   
        }
    }
}