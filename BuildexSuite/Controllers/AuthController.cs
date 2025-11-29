using BuildexSuite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BuildexSuite.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]  UserDTO user)
        {
            // Call your Web API
            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://localhost:7093/api/auth/AddUser", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            return Content(responseContent, "application/json");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            // Call your Web API
            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://localhost:7093/api/auth/Login", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            return Content(responseContent, "application/json");
        }
    }
}
