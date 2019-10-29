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
            JeuPlusMoins();
        }

        private static void JeuPlusMoins()
        {
            int min = 0;
            int max = 100;
            int val;
            int userVal;
            int bestScore = 50;

            int[] arrayVal = new int[20];
            int[] arrayTries = new int[20];

            int currentPlay = -1;

            do
            {
                int tries = 0;
                currentPlay++;

                Random rand = new Random();
                val = rand.Next(min, max + 1);

                do
                {
                    userVal = GetInt();
                    if (userVal == -1)
                    {
                        continue;
                    }
                    tries++;

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
                        StringBuilder bestScoreText = new StringBuilder();

                        if (tries < bestScore)
                        {
                            bestScoreText.Append("you beat best score from ");
                            bestScoreText.Append(bestScore);
                            bestScoreText.Append(" to ");
                            bestScoreText.Append(tries);
                            bestScore = tries;
                        }
                        else
                        {
                            bestScoreText.Append("you have not beat best score ");
                            bestScoreText.Append(bestScore);
                            bestScoreText.Append(" tries");
                        }

                        Console.WriteLine("You find in {0} tries {1}", tries, bestScoreText.ToString());
                        arrayVal[currentPlay] = val;
                        arrayTries[currentPlay] = tries;
                    }

                } while (userVal != val);

            } while (!GetString().Equals("N"));

            PrintHistory(arrayVal: arrayVal, arrayTries: arrayTries, compteur: currentPlay + 1);
            Console.WriteLine("Thanks for playing");
            
            Console.ReadLine();
        }

        private static int GetInt()
        {
            int userVal;
            Console.WriteLine("Choose an int value between {0} and {1}", 0, 100);
            if (!int.TryParse(Console.ReadLine(), out userVal))
            {
                userVal = -1;
            }

            return userVal;
        }

        private static string GetString()
        {
            Console.WriteLine("Replay - O");
            Console.WriteLine("Quit - N");
            return Console.ReadLine();
        }

        private static void PrintHistory(int[] arrayTries, int[] arrayVal, int compteur = 20)
        {
            for (int i = 0; i < compteur; i++)
            {
                Console.WriteLine("Partie N°{0} , valeur secrète={1} , trouvé en {2} coup(s).", i + 1, arrayVal[i], arrayTries[i]);
            }
        }
    }
}
