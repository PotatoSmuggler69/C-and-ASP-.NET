using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfAPI2.Models;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace SelfAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.Username = request.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }
        private void CreatePasswordHash(String password, out byte[] passwordHash, out byte[] passwordSalt) {
            using (var hmac = new HMACSHA256()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }
    }
}
