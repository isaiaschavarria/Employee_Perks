using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using AppLogic;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VacationController : ControllerBase
    {

        [HttpPost]
        public void CreateVacation(Vacation vac)
        {
            VacationAdmin admin = new VacationAdmin();
            admin.CreateVacation(vac);
        }

        [HttpGet]
        //public List<Vacation> GetAllVacation() {
        //    VacationAdmin admin = new VacationAdmin();
        //    return admin.ReturnAllVacations();
        //}
        public API_Response GetAllVacation() {
            
            API_Response response = new API_Response();
            try
            {
                VacationAdmin admin = new VacationAdmin();

                response.Result = "OK";
                response.Data = admin.ReturnAllVacations();
                return response;
            }
            catch (Exception ex)
            {
                response.Result = "ERROR";
                response.Message = "There was an error loading the vacation data " + ex.Message;
                return response;
            }

        }

        [HttpGet]
        public Vacation GetVacationById(int id) 
        {
            VacationAdmin admin = new VacationAdmin();
            return admin.ReturnVacationById(id);
        }

        [HttpPut]
        public void UpdateVacationRequest(Vacation v)
        {
            VacationAdmin vacationManager = new VacationAdmin();
            vacationManager.UpdateVacation(v);
        }


        [HttpDelete]
        public void DeleteVacationRequest(int id)
        {
            VacationAdmin vacationManager = new VacationAdmin();
            vacationManager.Delete(id);
        }

    }
}
