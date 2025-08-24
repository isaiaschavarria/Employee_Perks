using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data;
using System.Data;

namespace DataAccess.Dao
{
    public class SqlDao
    {
        private string _connectionString = "Server=localhost; Database=EmployeePerks;Trusted_Connection=True;TrustServerCertificate=true";
        //private string _connectionString = "Server=tcp:employee-perks-isaias-server.database.windows.net,1433;Initial Catalog=EmployeePerks_Isaias_DB;Persist Security Info=False;User ID=employeePerksUser;Password=Proy22025*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        #region Singleton

        private static SqlDao instance = new SqlDao();

        public static SqlDao GetInstance() { 
            if(instance == null)
                instance = new SqlDao();
            return instance;
        }

        #endregion

        //C  reate

        //U  pdate
        //D  elete

        public void ExcecuteStoredProcedure(SqlOperation operation) { 
            
            //crear la conexion
            SqlConnection conn = new SqlConnection(_connectionString);

            //armar el query (stored procedure)
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = operation.ProcedureName;

            //agregar parametros
            foreach (var p in operation.parameters) {
                command.Parameters.Add(p);
            }
            //abrir la conexion
            conn.Open();

            //Ejecutar el procedure
            command.ExecuteNonQuery();

            //cerrar
            conn.Close();
        }

        //R  ead
        public List<Dictionary<string, object>> ExcecuteStoredProcedureWithQuery(SqlOperation operation) {

            List<Dictionary<string, object>> lstresults = new List<Dictionary<string, object>>();

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = operation.ProcedureName;

            //agregar parametros
            foreach (var p in operation.parameters)
            {
                command.Parameters.Add(p);
            }

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            //recorrer el reader y construir el dictionario
            if (reader.HasRows) {
                while (reader.Read()) { 
                    Dictionary<string, object> diccObj = new Dictionary<string, object>();

                    for (var fieldCount = 0; fieldCount < reader.FieldCount; fieldCount++) {
                        diccObj.Add(reader.GetName(fieldCount), reader.GetValue(fieldCount));
                    }
                    lstresults.Add(diccObj);
                }
            }
            return lstresults;
        }
    }
}
