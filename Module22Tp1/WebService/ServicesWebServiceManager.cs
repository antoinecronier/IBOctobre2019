using Module18TP1ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module22Tp1.WebService
{
    public class ServicesWebServiceManager : WebServiceManager<Service>
    {
        public ServicesWebServiceManager(string dataConnection) : base (dataConnection)
        {

        }
    }
}
