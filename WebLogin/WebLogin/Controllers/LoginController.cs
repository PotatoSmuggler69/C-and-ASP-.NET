using Microsoft.AspNetCore.Mvc;
using WebLogin.Models;
namespace WebLogin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult GetData() {
            return View();
        } 
        public IActionResult SetData(String user_id,String password)
        {
            Login obj = new Login();
            obj.user_id = user_id;
            obj.password = password;
            return View();
        }
    }
}
