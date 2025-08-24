using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using DTO;

//C v
//R d
    // RbId  d
    //RBName d
//U v
//D v

namespace AppLogic
{
    public class VacationAdmin
    {

        private VacationCrud vacationCrud;

        public VacationAdmin() { 
            vacationCrud = new VacationCrud();
        }

        public void CreateVacation(Vacation vac) {
            vacationCrud.Create(vac);
        }

        public List<Vacation> ReturnAllVacations() {
            return vacationCrud.RetrieveAll<Vacation>();
        }

        //public Vacation ReturnVacationById(int id) { 

        //    Vacation vacation = new Vacation();
        //    vacation.Id = 1;
        //    vacation.StartDay = DateTime.Now;
        //    vacation.EndDay = DateTime.Now.AddDays(5);
        //    vacation.EmployeeId = 01;
        //    vacation.Justification = "Vacacion de prueba mientras terminamos el proceso de Base de Datos";

        //    return vacation;
        //}

        public Vacation ReturnVacationById(int Id)
        {
            VacationCrud vcrud = new VacationCrud();
            return vcrud.RetrieveById<Vacation>(Id);
        }

        public void UpdateVacation(Vacation vac)
        {
            VacationCrud vcrud = new VacationCrud();
            vcrud.Update(vac);
        }

        public void Delete(int Id)
        {
            VacationCrud vcrud = new VacationCrud();
            vcrud.Delete(Id);
        }
    }
}
