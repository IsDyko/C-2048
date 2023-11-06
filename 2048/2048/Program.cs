using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Création du tableau

            int[,] tableau = new int[4, 4];

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++) 
                {
                    Console.Write(tableau[row, col] + "\t");
                }
                Console.WriteLine("\n\n");
            }
            Console.ReadKey();
        }
    }
}
