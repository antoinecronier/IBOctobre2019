using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4TP1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            V1();
            try
            {
                V2();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static void V1()
        {
            int number = int.MaxValue;

            Console.WriteLine(number);
            Console.WriteLine(++number);
            Console.ReadLine();
        }

        private static void V2()
        {
            checked
            {
                int number = int.MaxValue;

                Console.WriteLine(number);
                Console.WriteLine(++number);
                // Console.WriteLine(checked(++number));
            }

            Console.ReadLine();
        }
    }
}
