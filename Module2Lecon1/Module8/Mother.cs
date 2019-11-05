using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Lecon1.Module8
{
    public class Mother
    {
        protected int myVar;
        protected string myVar1;
        protected bool myVar2;
        private IActions actions;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public string MyProperty1
        {
            get { return myVar1; }
            set { myVar1 = value; }
        }

        public bool MyProperty2
        {
            get { return myVar2; }
            set { myVar2 = value; }
        }

        public IActions Actions
        {
            get { return actions; }
            set { actions = value; }
        }

        public Mother()
        {
        }

        public Mother(int myVar, string myVar1, bool myVar2)
        {
            this.myVar = myVar;
            this.myVar1 = myVar1;
            this.myVar2 = myVar2;
        }

        public virtual void Print()
        {
            Console.WriteLine("Print from Mother " + this.myVar1);
        }

        public void Print2()
        {
            Console.WriteLine("Print2 from Mother " + this.myVar1);
        }

        public virtual void Print3()
        {
            Console.WriteLine("Print3 from Mother " + this.myVar1);
        }

        //public abstract void Print4();
    }
}
