using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public interface ICrudQueries
    {
        SqlOperation GetCreateQuery(BaseClass entity);
        SqlOperation GetUpdateQuery(BaseClass entity);
        SqlOperation GetDeleteQuery(int Id);
        SqlOperation GetRetrieveAllQuery();
        SqlOperation GetRetrieveByIdQuery(int Id);

    }
}
