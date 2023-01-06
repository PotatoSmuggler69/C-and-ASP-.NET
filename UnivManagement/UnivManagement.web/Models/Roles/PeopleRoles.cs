using System.Text.Json.Serialization;

namespace UnivManagement.web.Models.Roles;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PeopleRoles
{
    Student = 1,
    Teacher = 2,
    Finance = 3,
    Security = 4
}
