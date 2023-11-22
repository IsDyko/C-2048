using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    internal class Program
    {
        static int[,] tableau = new int[4, 4];

        static void ClearScreen()
        {
            Console.Clear();
        }

        static void DisplayTableau()
        {
            for (int row = 0; row < tableau.GetLength(0); row++)
            {
                for (int col = 0; col < tableau.GetLength(1); col++)
                {
                    Console.Write(tableau[row, col] + "\t");
                }
                Console.WriteLine("\n");
            }
        }

        static int[,] UpdateTableau()
        {

            //Création de la règle random pour les nombres et création du nombre à rentrer

            Random random = new Random();
            int randomNumber2 = random.NextDouble() < 0.9 ? 2 : 4;

            //Création index random ligne / colonne et règle random pour index
            Random randomPosition = new Random();


            //Vérifier si la case du tableau est vide et si oui la remplir
            bool caseVide = false;

            while (!caseVide)
            {
                int randomRow = randomPosition.Next(0, 4);
                int randomCol = randomPosition.Next(0, 4);

                if (tableau[randomRow, randomCol] is 0)
                {
                    tableau[randomRow, randomCol] = randomNumber2;
                    caseVide = true;
                }
            }

            //Parcourir le tableau

            for (int row = 0; row < tableau.GetLength(0); row++)
            {
                for (int col = 0; col < tableau.GetLength(1); col++)
                {
                    Console.Write(tableau[row, col] + "\t");
                }
                Console.WriteLine("\n");
            }

            ClearScreen();
            DisplayTableau();

            return tableau;
        }

        static void Main(string[] args)
        {
            ClearScreen();

            //Détection de touches

            bool touche = true;

            while (touche)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey key = keyInfo.Key;

                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.DownArrow:
                        UpdateTableau();
                        break;

                    case ConsoleKey.C:
                        return;

                    default:
                        Console.WriteLine("La touche n'est pas reconnue");
                        break;
                }
            }
        }
    }
}