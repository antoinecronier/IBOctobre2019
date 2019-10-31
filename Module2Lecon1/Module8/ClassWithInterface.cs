using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Lecon1.Module8
{
    public class ClassWithInterface : IActions
    {
        public string DoSomething()
        {
            string result = "DoSomething from ClassWithInterface";
            Console.WriteLine(result);
            return result;
        }

        public void DoSomething1(string data)
        {
            Console.WriteLine(data);
        }
    }
}
