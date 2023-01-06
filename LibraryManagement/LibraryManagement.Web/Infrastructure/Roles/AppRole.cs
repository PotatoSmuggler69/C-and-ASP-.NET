using System.Text.Json.Serialization;

namespace LibraryManagement.Web.Infrastructure.Roles
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AppRole
    {
        Member = 1,
        Librarian = 2
    }
}
