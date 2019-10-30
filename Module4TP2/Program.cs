using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4TP2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if (!int.TryParse("test", out _))
                {
                    throw new Exception("La valeur saisie n’est pas valide.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }
    }
}
