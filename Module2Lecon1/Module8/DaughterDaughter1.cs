using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Lecon1.Module8
{
    public class DaughterDaughter1 : Daughter1
    {
        public DaughterDaughter1(int a, string b, bool c) : base(a, b, c)
        {
        }

        public override void Print()
        {
            base.Print();
        }

        public new void Print3()
        {
            base.Print3();
        }

        public override void DoSomething1(string data)
        {
            base.DoSomething1(data);
        }
    }
}
