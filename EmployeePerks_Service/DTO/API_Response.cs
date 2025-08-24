using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class API_Response
    {
        public object Data { get; set; } //resultado de datos en caso de ser ub Get
        public string Result { get; set; } // OK, ERROR
        public string Message { get; set; } // Mensaje de error
    }
}
