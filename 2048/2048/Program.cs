using System;

namespace _2048
{
    internal class Program
    {
        static int[,] tableau = new int[4, 4];

        static void Main(string[] args)
        {
            ClearScreen();
            AddNewNumber();
            DisplayTableau();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        MoveLeft();
                        AddNewNumber();
                        ClearScreen();
                        DisplayTableau();
                        break;
                    case ConsoleKey.UpArrow:
                        MoveUp();
                        AddNewNumber();
                        ClearScreen();
                        DisplayTableau();
                        break;
                    case ConsoleKey.RightArrow:
                        MoveRight();
                        AddNewNumber();
                        ClearScreen();
                        DisplayTableau();
                        break;
                    case ConsoleKey.DownArrow:
                        MoveDown();
                        AddNewNumber();
                        ClearScreen();
                        DisplayTableau();
                        break;
                    case ConsoleKey.C:
                        return;
                    default:
                        Console.WriteLine("La touche n'est pas reconnue");
                        break;
                }
            }
        }

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

        static void AddNewNumber()
        {
            Random random = new Random();
            int randomNumber2 = random.NextDouble() < 0.9 ? 2 : 4;

            bool caseVide = false;
            while (!caseVide)
            {
                int randomRow = random.Next(0, 4);
                int randomCol = random.Next(0, 4);

                if (tableau[randomRow, randomCol] == 0)
                {
                    tableau[randomRow, randomCol] = randomNumber2;
                    caseVide = true;
                }
            }
        }


        static void MoveUp()
        {
            for (int col = 0; col < tableau.GetLength(1); col++)
            {
                // Slide all numbers upwards
                for (int row = 1; row < tableau.GetLength(0); row++)
                {
                    if (tableau[row, col] != 0)
                    {
                        int currentRow = row;
                        while (currentRow > 0 && tableau[currentRow - 1, col] == 0)
                        {
                            tableau[currentRow - 1, col] = tableau[currentRow, col];
                            tableau[currentRow, col] = 0;
                            currentRow--;
                        }
                    }
                }

                // Merge numbers
                for (int row = 1; row < tableau.GetLength(0); row++)
                {
                    if (tableau[row - 1, col] == tableau[row, col] && tableau[row, col] != 0)
                    {
                        tableau[row - 1, col] *= 2;
                        tableau[row, col] = 0;
                        row++; // Skip the next cell
                    }
                }
            }
        }



        static void MoveRight()
        {
            for (int row = 0; row < tableau.GetLength(0); row++)
            {
                // Slide all numbers to the right
                for (int col = tableau.GetLength(1) - 2; col >= 0; col--)
                {
                    if (tableau[row, col] != 0)
                    {
                        int currentCol = col;
                        while (currentCol < tableau.GetLength(1) - 1 && tableau[row, currentCol + 1] == 0)
                        {
                            tableau[row, currentCol + 1] = tableau[row, currentCol];
                            tableau[row, currentCol] = 0;
                            currentCol++;
                        }
                    }
                }

                // Merge numbers
                for (int col = tableau.GetLength(1) - 2; col >= 0; col--)
                {
                    if (tableau[row, col + 1] == tableau[row, col] && tableau[row, col] != 0)
                    {
                        tableau[row, col + 1] *= 2;
                        tableau[row, col] = 0;
                        col--; // Skip the next cell
                    }
                }
            }
        }



        static void MoveDown()
        {
            for (int col = 0; col < tableau.GetLength(1); col++)
            {
                // Slide all numbers downwards
                for (int row = tableau.GetLength(0) - 2; row >= 0; row--)
                {
                    if (tableau[row, col] != 0)
                    {
                        int currentRow = row;
                        while (currentRow < tableau.GetLength(0) - 1 && tableau[currentRow + 1, col] == 0)
                        {
                            tableau[currentRow + 1, col] = tableau[currentRow, col];
                            tableau[currentRow, col] = 0;
                            currentRow++;
                        }
                    }
                }

                // Merge numbers
                for (int row = tableau.GetLength(0) - 2; row >= 0; row--)
                {
                    if (tableau[row + 1, col] == tableau[row, col] && tableau[row, col] != 0)
                    {
                        tableau[row + 1, col] *= 2;
                        tableau[row, col] = 0;
                        row--; // Skip the next cell
                    }
                }
            }
        }



        static void MoveLeft()
        {
            Console.WriteLine("Moving Left"); // Debugging line

            for (int row = 0; row < tableau.GetLength(0); row++)
            {
                // First slide all numbers to the left
                for (int col = 1; col < tableau.GetLength(1); col++)
                {
                    if (tableau[row, col] != 0)
                    {
                        int currentCol = col;
                        while (currentCol > 0 && tableau[row, currentCol - 1] == 0)
                        {
                            tableau[row, currentCol - 1] = tableau[row, currentCol];
                            tableau[row, currentCol] = 0;
                            currentCol--;
                        }
                    }
                }

                // Then merge numbers
                for (int col = 1; col < tableau.GetLength(1); col++)
                {
                    if (tableau[row, col - 1] == tableau[row, col] && tableau[row, col] != 0)
                    {
                        tableau[row, col - 1] *= 2;
                        tableau[row, col] = 0;

                        // Skip the next cell to avoid multiple merges
                        col++;
                    }
                }
                Console.WriteLine($"After processing row {row}:");
                DisplayTableau();

            }
        }
    }
}

        /*FIN*/

