using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Lecon1.Module19
{
    public class Module19
    {
        public void Test1()
        {
            var obj = new { Name = "testName", Age = 10 };
            
            Console.WriteLine(obj.Name);
            Console.WriteLine(obj);

            List<object> objList = new List<object>();
            objList.Add(obj);

            //object obj = new { Name = "testName", Age = 10 };
        }

        public void Calc1(int a, int b)
        {
            Console.WriteLine((a + b));
        }

        public int Calc2(int a, int b)
        {
            return a + b;
        }

        public void FuncManipulation()
        {
            Action action1 = () =>
            {
                Console.WriteLine("Anonymous Action 1");
            };
            action1.Invoke();


            action1 = Test1;
            action1.Invoke();

            Action<int,int> action2 = Calc1;
            action2.Invoke(10,20);

            Func<int, int, int> f1 = Calc2;
            Console.WriteLine(f1.Invoke(10, 40));

            f1 = (int a, int b) =>
            {
                return a + b;
            };

            Console.WriteLine(f1.Invoke(20, 40));
        }

        public void LinqExample()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 20; i++)
            {
                people.Add(new Person() { Firstname = "f" + i, Lastname = "l" + i, Age = i * 2 });
            }

            Console.WriteLine(people.Average(x => x.Age));
            Console.WriteLine(people.Where(x => x.Age > 20).Average(x => x.Age));

            foreach (var item in people.Where(x => x.Age > 20))
            {
                Console.WriteLine(item.Lastname);
            }

            foreach (var item in people.OrderByDescending(x => x.Age))
            {
                Console.WriteLine(item.Lastname + " " + item.Firstname + " " + item.Age);
            }
        }

        private class Person
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public int Age { get; set; }
        }
    }
}
