using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2TP1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = 0;
            int percent = 0;
            int minute = 0;
            //int guess = 0;
            int answer = 0;

            if (number % 2 == 0)
            {

            }
            if ((percent < 0) || (percent > 100))
            {

            }

            if (minute == 60) minute = 0;

            for (int j = 0; j < 10; j++)
                Console.WriteLine(j);

            int i = 0;
            while (i < 10)
                Console.WriteLine(i);

            for (int j = 0; !(j >= 10); j++)
                Console.WriteLine(i);

            int guess;
            do
            {
                string line = Console.ReadLine();
                guess = int.Parse(line);
            } while (guess != answer);

            int[] array = { 0, 2, 4, 6 };
            int[] array1 = array;
            Console.WriteLine(array1[0]);
            int[] array2 = new int[3];
            Console.WriteLine(array2[2]);
            int[] array3 = new int[1];
            int[] array4 = new int[4] { 0, 1, 2, 3 };
        }
    }
}
