using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Lecon1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Standard data types
            Console.WriteLine("{0} : min = {1}, max {2}", "int", int.MinValue, int.MaxValue);
            Console.WriteLine("{0} : min = {1}, max {2}", "uint", uint.MinValue, uint.MaxValue);
            Console.WriteLine("{0} : min = {1}, max {2}", "float", float.MinValue, float.MaxValue);
            Console.WriteLine("{0} : min = {1}, max {2}", "ulong", ulong.MinValue, ulong.MaxValue);
            Console.WriteLine("{0} : min = {1}, max {2}", "double", double.MinValue, double.MaxValue);
            Console.WriteLine("{0} : faux = {1}, vrai {2}", "boolean", bool.FalseString, bool.TrueString);
            Console.ReadLine();

            // Cast
            int intVal = 10;
            double doubleVal = intVal;
            intVal = (int) doubleVal;
            Console.WriteLine(intVal);
            doubleVal = double.MaxValue;
            // Memory dump
            intVal = (int) doubleVal;
            Console.WriteLine(intVal);

            // Parse
            int.TryParse(doubleVal.ToString(), out intVal);
            Console.WriteLine(intVal);

            // Print ascii table
            for (int i = 0; i < 127; i++)
            {
                Console.Write((char)i);
            }
            Console.WriteLine();

            // Object ToString() representation
            Object object1 = new Object();

            Console.WriteLine(object1);

            Console.ReadLine();
        }
    }
}
