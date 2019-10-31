using Module8TP2ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8TP2GestionRH
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Employe employe = new Employe("test", "test", "test", 10, "test", 10D);
            Console.WriteLine(employe.Info());
            Personne personne = new Personne("test1", "test1");
            Console.WriteLine(personne.Info());
            Employe employe1 = new Employe(personne, "test2", 20D);
            Console.WriteLine(employe1.Info());
            employe1.SalaryIncrease(33.26);
            employe1.Assignment("new assignment");
            Console.WriteLine(employe1.Info());
            Console.ReadLine();
        }
    }
}
