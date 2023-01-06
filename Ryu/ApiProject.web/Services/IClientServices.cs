using ApiProject.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.web.Services
{
    public interface IClientServices
    {
        Task<ServiceResponse<List<ClientInfo>>> FetchClientDataList();
        Task<ServiceResponse<ClientInfo>> FetchClientData(string UsernameID);

        Task<ServiceResponse<ClientInfo>> AddClientData(ClientInfo _newClientInfo);
    }
}
