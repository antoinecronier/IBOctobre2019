﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8TP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = null;

            do
            {
                Console.WriteLine("Firstname = ?");
                string fName = Console.ReadLine();
                Console.WriteLine("Lastname = ?");
                string lName = Console.ReadLine();
                player = new Player(fName, lName);
            } while ((player.Firstname + player.Lastname).Equals(""));

            JeuPlusMoins(player);
        }

        private static void JeuPlusMoins(Player player)
        {
            int min = 1;
            int max = 5;
            int val;
            int userVal = int.MinValue;
            int bestScore = 50;

            int currentPlay = -1;

            do
            {
                int tries = 0;
                currentPlay++;

                Random rand = new Random();
                val = rand.Next(min, max + 1);

                player.Games[currentPlay] = new Game(val);

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
                        player.Games[currentPlay].Tries = tries;
                    }

                } while (userVal != val);
                Console.WriteLine("Replay - O");
                Console.WriteLine("Quit - N");
            } while (!GetString().Equals("N"));

            PrintHistory(arrayGame: player.Games, compteur: currentPlay + 1, fileName: player.Firstname + player.Lastname + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", ""));

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

        private static void PrintHistory(Game[] arrayGame, int compteur)
        {
            for (int i = 0; i < compteur; i++)
            {
                Console.WriteLine("Partie N°{0}, {1}", i + 1, arrayGame[i].Info());
            }
        }

        private static void PrintHistory(Game[] arrayGame, int compteur, string fileName)
        {
            FileStream destFile = null;
            StreamWriter writer = null;

            try
            {
                destFile = new FileStream("./" + fileName, FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(destFile);

                for (int i = 0; i < compteur; i++)
                {
                    writer.WriteLine("Partie N°{0} , ", i + 1, arrayGame[i].Info());
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
