using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnivManagement.web.Infrastructure;
using UnivManagement.web.Models;
using UnivManagement.web.Services;

namespace UnivManagement.web.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoController : ControllerBase
    {
        private readonly IStudentServices _StudentServices;


        public StudentInfoController(IStudentServices studentServices)
        {
            _StudentServices = studentServices;
        }
        [HttpGet("Get All Data")]
        public ActionResult<List<PeopleInfo>> Getall() {
            try
            {
                return Ok(_StudentServices.GetAllInfo());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("Get by Email")]
        public ActionResult<PeopleInfo> GetSpecific(String email)
        {
            try
            {
                return Ok(_StudentServices.GetSpecificInfo(email));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Add Data")]
        public ActionResult<String> GetSpecific(PeopleInfo peopleInfo)
        {
            try
            {
                _StudentServices.SetSpecificInfo(peopleInfo);
                return Ok("Successfully Added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
