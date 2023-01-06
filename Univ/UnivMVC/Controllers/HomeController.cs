using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;
using UnivMVC.Models;

namespace UnivMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Food> item = new List<Food>();
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7227/");
            HttpResponseMessage response = await client.GetAsync("api/Foods");
            if (response.IsSuccessStatusCode) { 
                var result = response.Content.ReadAsStringAsync().Result;
                item = JsonConvert.DeserializeObject<List<Food>>(result);
            }
            return View(item);
        }




    }
}