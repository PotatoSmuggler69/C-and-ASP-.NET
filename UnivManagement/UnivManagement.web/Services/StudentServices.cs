using UnivManagement.web.Infrastructure;
using UnivManagement.web.Models.Service_Models;
using UnivManagement.web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace UnivManagement.web.Services
{
    public class StudentServices : IStudentServices
    {
        public readonly DBObject _DBObject;
        // Dependecy Injection used for database
        public StudentServices(DBObject dBObject)
        {
            _DBObject = dBObject;
        }
        public async Task<ServiceResponse<List<PeopleInfo>>> GetAllInfo() {
            var _ServiceResponse = new ServiceResponse<List<PeopleInfo>>();
            List<PeopleInfo> result = _DBObject.PeopleInfoTable.ToList();
            _ServiceResponse.Data = result;
            return _ServiceResponse;
        }

        public async Task<ServiceResponse<PeopleInfo>> GetSpecificInfo(String email) { 
            var _ServiceResponse = new ServiceResponse<PeopleInfo>();
            var result =  _DBObject.PeopleInfoTable.FirstOrDefault(c => c.Email.Equals(email));
            if (result == null)
            {
                _ServiceResponse.IsSuccess = false;
                _ServiceResponse.Message = "No match found";
                return _ServiceResponse;
            }
            else {
                _ServiceResponse.Data = result;
                _ServiceResponse.Message = "Match Found Successfully";
                return _ServiceResponse;
            }

        }
        public async Task SetSpecificInfo(PeopleInfo peopleInfo) {
            var _ServiceResponse = new ServiceResponse<PeopleInfo>();
            await _DBObject.PeopleInfoTable.AddAsync(peopleInfo);
            await _DBObject.SaveChangesAsync();
        }
    }
}
