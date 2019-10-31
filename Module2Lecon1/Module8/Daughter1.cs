using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Lecon1.Module8
{
    public class Daughter1 : Mother, IActions
    {
        //private new string myVar1;

        private int myVar3;

        public int MyProperty3
        {
            get { return myVar3; }
            set { myVar3 = value; }
        }

        private string myVar4;

        public string MyProperty4
        {
            get { return myVar4; }
            set { myVar4 = value; }
        }


        public Daughter1(int a, string b, bool c) : base(a,b,c)
        {
            this.myVar1 = b;
        }

        public Daughter1()
        {
            this.Actions = new ClassWithInterface();
        }

        public override void Print()
        {
            //base.Print();
            Console.WriteLine("Print from Daughter1 " + this.myVar1);
        }

        public new void Print2()
        {
            Console.WriteLine("Print2 from Daughter1 " + this.myVar1);
        }

        public sealed override void Print3()
        {
            base.Print3();
        }

        public string DoSomething()
        {
            string result = "DoSomething from Daughter1";
            Console.WriteLine(result);
            return result;
        }

        public virtual void DoSomething1(string data)
        {
            Console.WriteLine(data + " from daughter1");
        }

        public override void Print4()
        {
            Console.WriteLine("Print4 from Daughter 1");
        }
    }
}
