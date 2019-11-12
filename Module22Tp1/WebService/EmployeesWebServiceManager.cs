using Module18TP1ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Module22Tp1.WebService
{
    public class EmployeesWebServiceManager : WebServiceManager<Employee>
    {
        public EmployeesWebServiceManager(string dataConnection) : base(dataConnection)
        {
        }

        public async Task<List<Employee>> GetEmployeesWithService()
        {
            List<Employee> result = new List<Employee>();
            result = await this.HttpClientCaller<List<Employee>>("/EmployeesWithService", result);
            return result;
        }

        public async Task<List<Employee>> GetEmployeesByLastname(string lastname)
        {
            List<Employee> result = new List<Employee>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(DataConnectionResource);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
               

                HttpResponseMessage response = await client.GetAsync("/EmployeesByLastname?choice="+lastname);
                result = await HandleResponse(result, response);
            }
            
            return result;
        }
    }
}
