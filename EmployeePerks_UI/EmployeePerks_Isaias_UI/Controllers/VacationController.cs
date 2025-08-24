using Microsoft.AspNetCore.Mvc;

namespace EmployeePerks_Isaias_UI.Controllers
{
    public class VacationController : Controller
    {
        //api--> applicatioName/api/Employee/GetAllEmployees
        //mvc --> application/Controller/Method
        //                    Vacation/CreateVacation
        public IActionResult CreateVacation()
        {
            return View();
        }

        public IActionResult VacationList()
        {
            if(HttpContext.Session.GetString("user") != null)
                return View();
            else
                return RedirectToAction("Login", "Login");

        }
    }
}
