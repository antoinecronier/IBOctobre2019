using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2TP2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int valMin = int.Parse(args[0]);
            int valMax = int.Parse(args[1]);
            int val;
            int userVal;
            int replay;

            Random rand = new Random();
            val = rand.Next(valMin, valMax + 1);

            do
            {
                do
                {
                    Console.WriteLine("Choose an int value");
                    if (!int.TryParse(Console.ReadLine(), out userVal))
                    {
                        Console.WriteLine("Not an int value");
                        continue;
                    }

                    if (userVal < val)
                    {
                        Console.WriteLine("It is more");
                    }
                    else if (userVal > val)
                    {
                        Console.WriteLine("It is less");
                    }
                    else
                    {
                        Console.WriteLine("You find");
                    }

                } while (userVal != val);

                do
                {
                    Console.WriteLine("Replay - 1");
                    Console.WriteLine("Quit - 2");
                    if (!int.TryParse(Console.ReadLine(), out replay))
                    {
                        Console.WriteLine("Not an int value");
                        continue;
                    }
                    
                } while (replay != 1 || replay != 2);

            } while (replay != 2);

            Console.WriteLine("Thanks for playing");
            Console.ReadLine();
        }
    }
}
