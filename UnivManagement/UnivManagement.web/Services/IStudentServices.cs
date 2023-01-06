using UnivManagement.web.Models;
using UnivManagement.web.Models.Service_Models;

namespace UnivManagement.web.Services
{
    public interface IStudentServices
    {
        public Task<ServiceResponse<List<PeopleInfo>>> GetAllInfo();
        public Task<ServiceResponse<PeopleInfo>> GetSpecificInfo(String email);

        public Task SetSpecificInfo(PeopleInfo peopleInfo);

    }
}
