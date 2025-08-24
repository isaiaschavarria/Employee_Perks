using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class VacationMapper : ICrudQueries, IObjectMapper
    {
        public SqlOperation GetCreateQuery(BaseClass entity)
        {
          // @EmployeeId
          //,@StartDay
          //,@EndDay
          //,@Justification
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_VACATION";

            Vacation vac = (Vacation)entity;
            operation.AddIntegerParameter("EmployeeId", vac.EmployeeId);
            operation.AddDatetimeParameter("StartDay", vac.StartDay);
            operation.AddDatetimeParameter("EndDay", vac.EndDay);
            operation.AddVarcharParameter("Justification", vac.Justification);

            return operation;
        }

        public SqlOperation GetDeleteQuery(int Id)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_DELETE_VACATION";

            operation.AddIntegerParameter("Id", Id);

            return operation;
        }

        public SqlOperation GetRetrieveAllQuery()
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_SELECT_ALL_VACATION";
            return operation;
        }

        public SqlOperation GetRetrieveByIdQuery(int Id)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_SELECT_VACATION_BY_Id";

            operation.AddIntegerParameter("Id", Id);

            return operation;
        }

        //getRetrieveByDate(DateTime startDate)
        //{
            //operation
            //operation.procedure = "mi nuevo procedure"
            //enviarParametros(fecha)
       // }

        public SqlOperation GetUpdateQuery(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_UPDATE_VACATION";

            Vacation vac = (Vacation)entityDTO;

            operation.AddIntegerParameter("Id", vac.Id);
            operation.AddIntegerParameter("EmployeeId", vac.EmployeeId);
            operation.AddDatetimeParameter("StartDay", vac.StartDay);
            operation.AddDatetimeParameter("EndDay", vac.EndDay);
            operation.AddVarcharParameter("Justification", vac.Justification);

            return operation;
        }

        public BaseClass MapObject(Dictionary<string, object> objectRow)
        {
            Vacation v = new Vacation();
            v.Id = int.Parse(objectRow["Id"].ToString());
            v.EmployeeId = int.Parse(objectRow["EmployeeId"].ToString());
            v.StartDay = DateTime.Parse(objectRow["StartDay"].ToString());
            v.EndDay = DateTime.Parse(objectRow["EndDay"].ToString());
            v.Justification = objectRow["Justification"].ToString();
            v.Active = Boolean.Parse(objectRow["Active"].ToString());

            return v;
        }

        public List<BaseClass> MapObjectList(List<Dictionary<string, object>> objectList)
        {
            var list = new List<BaseClass>();

            foreach (var row in objectList)
            {
                var vac = MapObject(row);
                list.Add(vac);
            }
            return list;
        }
    }
}
