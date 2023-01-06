using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LibraryManagement.Web.Models;
using LibraryManagement.Web.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Web.Services
{
    public class AuthServices : IAuthServices
    {
        
        private readonly DbObject _dbObject;
        private readonly IConfiguration _configuration;
        public AuthServices(DbObject dbObject,IConfiguration configuration)
        {
            _dbObject = dbObject;   
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(string Email, string Password)
        {
            var response = new ServiceResponse<string>();
            var _member = await _dbObject.MemberTable.FirstOrDefaultAsync(u => u.Email.ToLower() == Email.ToLower());
            //User name auth validation
            if (_member == null)
            {
                response.Success = false;
                response.Message = "Member not found!";
                new Error(response.Message + " Email = " + Email + " does not exist");
            }
            //Password auth 
            else if (!VerifyPasswordHash(Password, _member.PasswordHash, _member.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Password";
                new Error(response.Message + " Company = " + Email + " present in Database. But Password did not match");
            }
            else
            {
                response.Message = "Logged In";
                response.Data = CreateToken(_member);
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(Member request, string Password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await UserAlreadyExist(request.Email))
            {
                response.Success = false;
                response.Message = "User Already Exists";
                return response;
            }
            CreatePasswordHash(Password, out byte[] PasswordHash, out byte[] PasswordSalt);

            request.PasswordSalt = PasswordSalt;
            request.PasswordHash = PasswordHash;

            _dbObject.MemberTable.Add(request);
            await _dbObject.SaveChangesAsync();

            response.Data = request.MemberId;
            return response;
        }



        public async Task<bool> UserAlreadyExist(string Email)
        {
            if (await _dbObject.MemberTable.AnyAsync(u => u.Email.ToLower() == Email.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string Password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
        }
        private bool VerifyPasswordHash(string Password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
            {
                var ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                return (ComputeHash.SequenceEqual(PasswordHash));
            }
        }

        private string CreateToken(Member member)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,member.MemberId.ToString()),
                new Claim(ClaimTypes.Name,member.Name),
                new Claim(ClaimTypes.Email,member.Email),
                new Claim(ClaimTypes.Role,member.Role.ToString())
            };
            SymmetricSecurityKey Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = (DateTime.Now.AddMinutes(15)),
                SigningCredentials = Creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


    }
}
