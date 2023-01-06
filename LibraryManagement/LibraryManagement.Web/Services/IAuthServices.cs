using LibraryManagement.Web.Infrastructure;
using LibraryManagement.Web.Models;

namespace LibraryManagement.Web.Services
{
    public interface IAuthServices
    {
        Task<ServiceResponse<String>> Login(string Email, string Password);
        Task<ServiceResponse<int>> Register(Member request,string Password);

    }
}
