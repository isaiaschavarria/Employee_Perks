using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Vacation : BaseClass
    {
        //public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public string Justification { get; set; }
        public bool Active { get; set; }
    }
}
