﻿using System;

namespace _2048
{
    internal class Program
    {
        static int[,] tableau = new int[4, 4];
        static int score = 0; // New score variable
        static bool isGameOver = false; // New flag to track if the game is over



        static void Main(string[] args)
        {
            ClearScreen();
            AddNewNumber();
            DisplayTableau();

            while (true)
            {
                if (!isGameOver)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.DownArrow:
                            ProcessInput(keyInfo.Key);
                            ClearScreen();
                            DisplayTableau();

                            if (CheckWin())
                            {
                                Console.WriteLine("You Win!");
                                isGameOver = true;
                            }
                            else if (!CanMakeMove())
                            {
                                Console.WriteLine("Game Lost");
                                isGameOver = true;
                            }
                            else
                            {
                                AddNewNumber();
                            }
                            break;
                        case ConsoleKey.C:
                            return; // Exit the game
                        default:
                            Console.WriteLine("La touche n'est pas reconnue");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPress 'C' to exit...");
                    if (Console.ReadKey(true).Key == ConsoleKey.C)
                    {
                        return;
                    }
                }
            }
        }


        static void ProcessInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
            }
        }

        static void ClearScreen()
        {
            Console.Clear();
        }

        static void DisplayTableau()
        {
            Console.WriteLine("Score: " + score);
            for (int row = 0; row < tableau.GetLength(0); row++)
            {
                for (int col = 0; col < tableau.GetLength(1); col++)
                {
                    SetConsoleColor(tableau[row, col]);
                    Console.Write($"{tableau[row, col],4}");
                    Console.ResetColor();
                }
                Console.WriteLine("\n");
            }
        }


        static void AddNewNumber()
        {
            Random random = new Random();
            int randomNumber2 = random.NextDouble() < 0.9 ? 2 : 4;

            if (!CanAddNewNumber())
            {
                return; // Exit the method if no empty space is available
            }

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

        static bool CanAddNewNumber()
        {
            for (int row = 0; row < tableau.GetLength(0); row++)
            {
                for (int col = 0; col < tableau.GetLength(1); col++)
                {
                    if (tableau[row, col] == 0)
                    {
                        return true; // Found an empty space
                    }
                }
            }
            return false; // No empty spaces
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
                        score += tableau[row - 1, col];
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
                        score += tableau[row, col + 1];
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
                        score += tableau[row + 1, col];
                        row--; // Skip the next cell
                    }
                }
            }
        }



        static void MoveLeft()
        {
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

                // merge numbers
                for (int col = 1; col < tableau.GetLength(1); col++)
                {
                    if (tableau[row, col - 1] == tableau[row, col] && tableau[row, col] != 0)
                    {
                        tableau[row, col - 1] *= 2;
                        tableau[row, col] = 0;
                        score += tableau[row, col - 1];

                        // Skip the next cell to avoid multiple merges
                        col++;
                    }
                }
                DisplayTableau();

            }
        }

        static bool CanMakeMove()
        {
            for (int row = 0; row < tableau.GetLength(0); row++)
            {
                for (int col = 0; col < tableau.GetLength(1); col++)
                {
                    if (tableau[row, col] == 0)
                        return true; // Empty space found

                    if (row < tableau.GetLength(0) - 1 && tableau[row, col] == tableau[row + 1, col])
                        return true; // Vertical move possible

                    if (col < tableau.GetLength(1) - 1 && tableau[row, col] == tableau[row, col + 1])
                        return true; // Horizontal move possible
                }
            }

            return false;
        }

        static bool CheckWin()
        {
            for (int row = 0; row < tableau.GetLength(0); row++)
            {
                for (int col = 0; col < tableau.GetLength(1); col++)
                {
                    if (tableau[row, col] == 2048)
                        return true;
                }
            }
            return false;
        }

        static void SetConsoleColor(int number)
        {
            switch (number)
            {
                case 0: Console.ForegroundColor = ConsoleColor.Gray; break;
                case 2: Console.ForegroundColor = ConsoleColor.Blue; break;
                case 4: Console.ForegroundColor = ConsoleColor.Cyan; break;
                case 8: Console.ForegroundColor = ConsoleColor.Green; break;
                case 16: Console.ForegroundColor = ConsoleColor.Magenta; break;
                case 32: Console.ForegroundColor = ConsoleColor.Red; break;
                case 64: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case 128: Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                case 256: Console.ForegroundColor = ConsoleColor.DarkCyan; break;
                case 512: Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case 1024: Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
                case 2048: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                default: Console.ForegroundColor = ConsoleColor.White; break; // For numbers higher than 2048
            }
        }

    }
}

/*FIN*/
