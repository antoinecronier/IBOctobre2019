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
            int replay;
            int bestScore = 50;
            
            int[][] plays = new int[20][];

            for (int i = 0; i < plays.Length; i++)
            {
                plays[i] = new int[2];
            }

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
                        plays[currentPlay][0] = val;
                        plays[currentPlay][1] = tries;
                    }

                } while (userVal != val);

            } while (!GetString().Equals("N"));

            PrintHistory(data: plays, compteur: currentPlay);
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

        private static void PrintHistory(int[][] data, int compteur = 20)
        {
            int loop = 1;
            foreach (int[] game in data)
            {
                Console.WriteLine("Partie N°{0} , valeur secrète={1} , trouvé en {2} coup(s).", loop, game[0], game[1]);
                if (loop == compteur + 1)
                {
                    break;
                }
                loop++;
            }
        }
    }
}
