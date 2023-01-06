using ApiProject.web.Insfrastructure;
using ApiProject.web.Models;
using ApiProject.web.Services;
using Microsoft.AspNetCore.Mvc;


namespace ApiProject.web.Controllers
{
    [ApiController]
    [Route("api/Controller")]
    public class ClientInfoController : ControllerBase
    {
        private readonly IClientServices _IClientService;
        public ClientInfoController(IClientServices iClient)
        {
            _IClientService = iClient;
        }
       

        [HttpGet("GetAll")]
        public ActionResult<List<ClientInfo>> Getall()
        {
            try
            {
                return Ok(_IClientService.FetchClientDataList());
            }
            catch (Exception e) { 
                return BadRequest(e.Message);
            }
            
        }
        [HttpGet("GetSpecific")]
        public ActionResult<ClientInfo> Get(string UsernameID)
        {
            try
            {
                return Ok(_IClientService.FetchClientData(UsernameID));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Post")]
        public async Task<string> Post(ClientInfo _newClientInfo)
        {
            try
            {
                await _IClientService.AddClientData(_newClientInfo);
                return ("Added");
            }
            catch (Exception e)
            {
                return (e.Message);
            }
        }
    }
}
