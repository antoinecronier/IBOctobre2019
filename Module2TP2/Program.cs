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
            //IAJeuPlusMoins(int.Parse(args[0]), int.Parse(args[1]));
            JeuPlusMoins(int.Parse(args[0]), int.Parse(args[1]));
        }

        private static void IAJeuPlusMoins(int min, int max)
        {
            int valMin = min;
            int valMax = max;
            int val;
            int userVal;
            int iaGame = 0;
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
                val = rand.Next(valMin, valMax + 1);

                do
                {
                    Console.WriteLine("Choose an int value between {0} and {1}", min, max);
                    userVal = rand.Next(valMin, valMax + 1);
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
                
                iaGame++;
            } while (iaGame < 20);

            Console.WriteLine("Thanks for playing");
            int loop = 1;
            foreach (int[] game in plays)
            {
                Console.WriteLine("Partie N°{0} , valeur secrète={1} , trouvé en {2} coup(s).", loop, game[0], game[1]);
                loop++;
            }
            Console.ReadLine();
        }

        private static void JeuPlusMoins(int min, int max)
        {
            int val;
            int userVal;
            int replay;
            int bestScore = 50;

            //int[,] test = new int[2, 2];
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
                    Console.WriteLine("Choose an int value between {0} and {1}", min, max);
                    if( !int.TryParse(Console.ReadLine(), out userVal) || 
                        (userVal < min || userVal > max))
                    {
                        Console.WriteLine("Not an int value");
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

                do
                {
                    Console.WriteLine("Replay - 1");
                    Console.WriteLine("Quit - 2");
                    if (!int.TryParse(Console.ReadLine(), out replay))
                    {
                        Console.WriteLine("Not an int value");
                        continue;
                    }

                } while (replay != 1 && replay != 2);

            } while (replay != 2);

            Console.WriteLine("Thanks for playing");
            int loop = 1;
            foreach (int[] game in plays)
            {
                Console.WriteLine("Partie N°{0} , valeur secrète={1} , trouvé en {2} coup(s).", loop, game[0], game[1]);
                loop++;
            }
            Console.ReadLine();
        }
    }
}
