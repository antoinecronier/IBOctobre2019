using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Greeter
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Datas for entry point.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("What's your name?");
            string myName = Console.ReadLine();
            string dataToPrint = "{0}'s : Welcome {0}";
            Console.WriteLine(dataToPrint, myName);
            Console.ReadLine();
        }
    }
}
