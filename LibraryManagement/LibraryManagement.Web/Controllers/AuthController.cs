using LibraryManagement.Web.DTOs.Auth;
using LibraryManagement.Web.Infrastructure;
using LibraryManagement.Web.Models;
using LibraryManagement.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibraryManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authService;

        public AuthController(IAuthServices authService)
        {
            _authService = authService;
        }
        /// <summary>
        /// Method For Register
        /// </summary>

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterDTO request)
        {
            var response = await _authService.Register
                (
                    new Member
                    {
                        Name = request.Name,
                        Email = request.Email,
                    },
                    request.Password
                );
            if (!response.Success)
            {
                new Error(response.Message);
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// Method To Login into System.This will add the JWT token at successfull attempt to log In
        /// </summary>

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(LoginDTO request)
        {
            var response = await _authService.Login(request.Email, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
