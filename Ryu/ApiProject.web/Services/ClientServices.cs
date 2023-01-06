using ApiProject.web.Insfrastructure;
using ApiProject.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.web.Services
{
    public class ClinetServices : IClientServices
    {
        private readonly DbInfo _dbInfo;
        public ClinetServices(DbInfo dbInfo)
        {
            _dbInfo=dbInfo;
        }
        public async Task<ServiceResponse<List<ClientInfo>>> FetchClientDataList()
        {
            var _ServiceResponse = new ServiceResponse<List<ClientInfo>>();
             List<ClientInfo> result = _dbInfo.ClientTable.ToList();
             _ServiceResponse.Data = result;
             return _ServiceResponse;
 
        }
        public async Task<ServiceResponse<ClientInfo>> FetchClientData(string UsernameID)
        {
            var _ServiceResponse = new ServiceResponse<ClientInfo>();                                                          
            List<ClientInfo> result = _dbInfo.ClientTable.ToList();
            _ServiceResponse.Data = result.FirstOrDefault(c => c.Username.Equals(UsernameID));
            return _ServiceResponse;
        }

        public async Task<ServiceResponse<ClientInfo>> AddClientData(ClientInfo _newClientInfo)
        {
            var _ServiceResponse = new ServiceResponse<ClientInfo>();
            _dbInfo.ClientTable.Add(_newClientInfo);
            
            await _dbInfo.SaveChangesAsync();
            List<ClientInfo> result = _dbInfo.ClientTable.ToList();
            _ServiceResponse.Data = result.FirstOrDefault(c => c.Username.Equals(_newClientInfo.Username));
            return _ServiceResponse;
        }
    }
}
