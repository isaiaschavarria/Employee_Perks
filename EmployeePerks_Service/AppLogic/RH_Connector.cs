using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Newtonsoft.Json;

namespace AppLogic
{
    public class RH_Connector
    {
        private const string SERVICE_URL_BASE = "https://rh-central.azurewebsites.net";

        public List<Employee> ReturnAllEmployees() {
            return this.Get_RH_Data();
        }

        private List<Employee> Get_RH_Data()
        {
            HttpClient client = new HttpClient();
            string uri = "/api/RH/GetAllEmployees";
            string final_url = SERVICE_URL_BASE + uri;

            client.BaseAddress = new Uri(final_url);

            var result = client.GetAsync(final_url).Result;

            if (result.IsSuccessStatusCode)
            {
                var jsonData = result.Content.ReadAsStringAsync().Result;
                var dtoObject = JsonConvert.DeserializeObject<List<Employee>>(jsonData);
                return dtoObject;
            }
            return null;
        }
    }
}
