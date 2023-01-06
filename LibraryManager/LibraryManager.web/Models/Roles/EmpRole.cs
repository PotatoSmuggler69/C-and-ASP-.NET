using System.Text.Json.Serialization;

namespace LibraryManager.web.Models.Roles
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EmpRole
    {
        Student = 1,
        Admin = 2,
        Employee = 3
    }
}
