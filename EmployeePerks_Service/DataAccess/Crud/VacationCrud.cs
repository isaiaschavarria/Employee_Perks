using DataAccess.Dao;
using DataAccess.Mapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class VacationCrud : CrudFactory
    {
        private VacationMapper mapper;

        public VacationCrud() : base() { 
            mapper = new VacationMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass entity)
        {
            SqlOperation operation = mapper.GetCreateQuery(entity);
            dao.ExcecuteStoredProcedure(operation);
        }

        public override void Delete(int Id)
        {
            SqlOperation operation = mapper.GetDeleteQuery(Id);
            dao.ExcecuteStoredProcedure(operation);
        }

        public override List<T> RetrieveAll<T>()
        {
            List<T> list = new List<T>();
            SqlOperation operation = mapper.GetRetrieveAllQuery();

            List<Dictionary<string, object>> dataResults = dao.ExcecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtObjects = mapper.MapObjectList(dataResults);
                foreach (var obj in dtObjects)
                {
                    list.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }
            return list;
        }

        public override T RetrieveById<T>(int id)
        {
            List<T> lstResults = new List<T>();
            SqlOperation operation = mapper.GetRetrieveByIdQuery(id);
            List<Dictionary<string, object>> vac = dao.ExcecuteStoredProcedureWithQuery(operation);

            var dtoObjects = mapper.MapObjectList(vac);

            var ob = dtoObjects.FirstOrDefault();

            return (T)Convert.ChangeType(ob, typeof(T));
        }

        //public override T RetrieveByStartDate<T>(DateTime startDate)
        //{
        //    List<T> lstResults = new List<T>();
        //    SqlOperation operation = mapper.GetRetrieveByIdQuery(id);
        //    List<Dictionary<string, object>> vac = dao.ExcecuteStoredProcedureWithQuery(operation);

        //    var dtoObjects = mapper.MapObjectList(vac);

        //    var ob = dtoObjects.FirstOrDefault();

        //    return (T)Convert.ChangeType(ob, typeof(T));
        //}

        public override void Update(BaseClass entityDTO)
        {
            SqlOperation operation = mapper.GetUpdateQuery(entityDTO);
            dao.ExcecuteStoredProcedure(operation);
        }
    }
}
