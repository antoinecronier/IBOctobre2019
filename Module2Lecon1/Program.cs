using Module2Lecon1.Module6;
using Module2Lecon1.Module8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module2Lecon1.Module6.Voiture;

namespace Module2Lecon1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Module8Test();
        }

        public static void Module8Test()
        {
            Mother mother = new Mother(10,"mother",true);
            mother.Print();
            mother.Print2();

            Console.WriteLine("--------------");

            Daughter1 daughter1 = new Daughter1(10, "daughter1", true);
            daughter1.Print();
            daughter1.Print2();
            //((Mother)daughter1).MyProperty1 = "mother";
            ((Mother)daughter1).Print();
            ((Mother)daughter1).Print2();

            Console.WriteLine("--------------");

            DaughterDaughter1 daughterDaughter1 = new DaughterDaughter1(10, "daughterdaughter1", true);
            daughterDaughter1.Print();
            daughterDaughter1.Print2();
            ((Daughter1)daughterDaughter1).Print();
            ((Daughter1)daughterDaughter1).Print2();
            ((Mother)daughterDaughter1).Print();
            ((Mother)daughterDaughter1).Print2();

            Console.ReadLine();
        }

        public enum MyEnum
        {
            Val1,
            Val2,
            Val3,
        }

        public static void EnumTest()
        {
            MyEnum en = MyEnum.Val3;
            Console.WriteLine((int)en);

            switch (en)
            {
                case MyEnum.Val1:
                    break;
                case MyEnum.Val2:
                    break;
                case MyEnum.Val3:
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        private static void Module6Test()
        {
            Voiture maVoiture = new Voiture();
            maVoiture.CoteVolant1 = Voiture.CoteVolant.Gauche;
            CoteVolant coteVolant = maVoiture.CoteVolant1;

            Voiture voiture1 = new Voiture(10, "zoijor", "zpoerpozer");
            //voiture1 = new Voiture();
            //Clone v1 to v2
            Voiture voiture2 = new Voiture(voiture1);

            
        }

        public void Module2()
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
            intVal = (int)doubleVal;
            Console.WriteLine(intVal);
            doubleVal = double.MaxValue;
            // Memory dump
            intVal = (int)doubleVal;
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
