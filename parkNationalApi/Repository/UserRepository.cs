using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using parkNationalApi.Data;
using parkNationalApi.Models;
using parkNationalApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace parkNationalApi.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly AppSettings _appsettings;
        public UserRepository(ApplicationDbContext context,IOptions<AppSettings> appsettings)
        {
            _context = context;
            _appsettings = appsettings.Value;
        }
        public User Authenticate(string username, string password)
        {
            var userindb = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (userindb == null) return null;
            //  create jwt code
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
            var tokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userindb.Id.ToString()),
                    new Claim(ClaimTypes.Role, userindb.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescritor);
            userindb.Token = tokenHandler.WriteToken(token);
            userindb.Password = " ";
            return userindb;
        }

        public bool isUnique(string username)
        {
            var user =  _context.Users.Any(u => u.Username == username);
            if (user)
            {
                return false;
            }
            return true;
            /* sir code*/
            /*var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }*/
        }

        public User Register(string username, string password)
        {
            User user = new User() { 
            Username = username,
            Password = password,
            Role = "Admin"
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
