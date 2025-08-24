using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using AppLogic;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public List<Employee> GetAllEmployees() { 
            RH_Connector rh = new RH_Connector();
            return rh.ReturnAllEmployees();
        }
    }
}
