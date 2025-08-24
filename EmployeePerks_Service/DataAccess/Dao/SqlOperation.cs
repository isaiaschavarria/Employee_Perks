using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccess.Dao
{
    public class SqlOperation
    {
        public string ProcedureName { get; set; }
        public List<SqlParameter> parameters;

        public SqlOperation() { 
            parameters = new List<SqlParameter>();
        }

        public void AddVarcharParameter(string parameterName, string parameterValue) {
            parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
        }

        public void AddIntegerParameter(string parameterName, int parameterValue)
        {
            parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
        }

        public void AddDatetimeParameter(string parameterName, DateTime parameterValue)
        {
            parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
        }

        public void AddBooleanParameter(string parameterName, bool parameterValue)
        {
            parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
        }

    }
}
