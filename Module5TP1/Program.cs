using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5TP1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            JeuPlusMoins();
        }

        private static void JeuPlusMoins()
        {
            int min = 1;
            int max = 5;
            int val;
            int userVal = int.MinValue;
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
                    try
                    {
                        userVal = GetInt();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
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
                Console.WriteLine("Replay - O");
                Console.WriteLine("Quit - N");
            } while (!GetString().Equals("N"));

            Console.WriteLine("Choose a filename to save or let empty");
            string fileName = GetString();
            if (fileName.Equals("") /*string.IsNullOrEmpty(fileName)*/)
            {
                PrintHistory(arrayVal: arrayVal, arrayTries: arrayTries, compteur: currentPlay + 1);
            }
            else
            {
                PrintHistory(arrayVal: arrayVal, arrayTries: arrayTries, compteur: currentPlay + 1, fileName: fileName);
            }
           
            Console.WriteLine("Thanks for playing");

            Console.ReadLine();
        }

        private static int GetInt()
        {
            int userVal;
            Console.WriteLine("Choose an int value between {0} and {1}", 0, 100);
            if (!int.TryParse(Console.ReadLine(), out userVal))
            {
                throw new Exception("Not an integer");
            }

            return userVal;
        }

        private static string GetString()
        {
            return Console.ReadLine();
        }

        private static void PrintHistory(int[] arrayTries, int[] arrayVal, int compteur)
        {
            for (int i = 0; i < compteur; i++)
            {
                Console.WriteLine("Partie N°{0} , valeur secrète={1} , trouvé en {2} coup(s).", i + 1, arrayVal[i], arrayTries[i]);
            }
        }

        private static void PrintHistory(int[] arrayTries, int[] arrayVal, int compteur, string fileName)
        {
            FileStream destFile = null;
            StreamWriter writer = null;

            try
            {
                destFile = new FileStream("./" + fileName, FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(destFile);

                for (int i = 0; i < compteur; i++)
                {
                    writer.WriteLine("Partie N°{0} , valeur secrète={1} , trouvé en {2} coup(s).", i + 1, arrayVal[i], arrayTries[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
                if (destFile != null)
                {
                    destFile.Close();
                }
            }

            Console.WriteLine("Save in file");
        }
    }
}
