using EmployeePerks_Isaias_UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePerks_Isaias_UI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(UserLogin u) {

            if (u.UserName == null || u.Password == null)
            {
                ViewBag.Message = "Usuario y/o password Incorrectos.";
                return View();
            }

            //Login se lleva a cabo correctamente
            //API --> LoginController --> LoginAdmin --> Mapper --> Dao --> SP
            //HttpClient client = new HttpClient();
            //client.PostAsync(Url api);




            u.Name = "Isaias Chavarria Mora";

            //Agregamos el valor en la sesion
            HttpContext.Session.SetString("user", u.Name);
            HttpContext.Session.SetString("userId", "1000000002");

            return RedirectToAction("Index", "Home");
        }
    }
}
