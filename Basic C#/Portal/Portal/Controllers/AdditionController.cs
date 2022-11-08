using Microsoft.AspNetCore.Mvc;
using Portal.Models;
namespace Portal.Controllers
{
    public class AdditionController : Controller
    {
        public IActionResult GetValue()
        {

            return View();
        }
        public IActionResult SetValue(int x, int y)
        {
            Addition obj = new Addition();
            obj.x=x;
            obj.y=y;
            obj.sum = x + y;

            return View(obj);
        }
    }
}
