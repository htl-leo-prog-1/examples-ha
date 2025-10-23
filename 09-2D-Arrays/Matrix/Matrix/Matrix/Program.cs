/**********************************************************************************************                                 
 * Programmname:    Matrix
 * Autor:           Michael Bucek  / Birgit Schröder
 * Datum:           25. 3. 2016                               
 * ------------------------------------------------ 
 * Description:  
 * The program "Matrix" creates a two-dimensional Integer array of arbitrary size and fills
 * it with random numbers between 1 and 9. 
 * Following, the numbers as well as the relations between the numbers are printed to the screen.
 * Below a line, the relations between vertically neighboured numbers are printed 
 * with 'V', 'A' and '='.
 ***********************************************************************************************/

using System;

namespace Matrix
{
    class Program
    {
        const ConsoleColor COLOR_NUMBER = ConsoleColor.Yellow;
        const ConsoleColor COLOR_LESS = ConsoleColor.Red;
        const ConsoleColor COLOR_GREATER = ConsoleColor.Red; 
        const ConsoleColor COLOR_EQUAL = ConsoleColor.Green;

        static void Main(string[] args)
        {
            string proceed = "j";
            do
            {
                int[,] numbers = CreateMatrix();
                CompareAndPrintMatrix(numbers);

                Console.Write("Neue Matrix? (j) ");
                proceed = Console.ReadLine();
            }
            while (proceed == "j");           
        }

        /// <summary>
        /// Asks for number rows and columns and creates and fills
        /// the corresponding matrix.
        /// </summary>
        /// <returns></returns>
        private static int[,] CreateMatrix()
        {
            Console.Write("Zeilen? \t");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Spalten? \t");
            int columns = Convert.ToInt32(Console.ReadLine());

            int[,] numbers = new int[rows, columns];
            Random random = new Random();
            //Matrix mit Zufallszahlen füllen
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int u = 0; u < numbers.GetLength(1); u++)
                {
                    numbers[i, u] = random.Next(1, 10);
                }
            }
            return numbers;
        }

        /// <summary>
        /// Evaluates the matrix and prints the numbers plus
        /// comparison operators to the Console.
        /// </summary>
        /// <param name="numbers"></param>
        private static void CompareAndPrintMatrix(int[,] numbers)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                CompareLineHorizontally(row, numbers);
                CompareLineVertically(row, numbers); 
            }
            Console.ForegroundColor = defaultColor;
        }

        /// <summary>
        /// This method prints a single line from the matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="numbers"></param>
        private static void CompareLineHorizontally(int row, int[,] numbers)
        {
            for (int col = 0; col < numbers.GetLength(1); col++)
            {
                //Vergleichsoperator für zwei Zahlen nebeneinander
                Console.ForegroundColor = COLOR_NUMBER;
                Console.Write(numbers[row, col]);
                if (col < numbers.GetLength(1) - 1) //Bei letzter Zahl kein Vegleichsoperator mehr
                {
                    if (numbers[row, col] < numbers[row, col + 1])
                    {
                        Console.ForegroundColor = COLOR_LESS;
                        Console.Write(" < ");
                    }
                    else if (numbers[row, col] > numbers[row, col + 1])
                    {
                        Console.ForegroundColor = COLOR_GREATER;
                        Console.Write(" > ");
                    }
                    else
                    {
                        Console.ForegroundColor = COLOR_EQUAL;
                        Console.Write(" = ");
                    }
                }
            }
            Console.WriteLine();
        }
        /// <summary>
        /// This method prints the vertical comparison operators
        /// under a given line
        /// </summary>
        /// <param name="row"></param>
        /// <param name="numbers"></param>
        private static void CompareLineVertically(int row, int[,] numbers)
        {
            for (int col = 0; col < numbers.GetLength(1); col++)
            {
                //Vergleichsoperator für zwei Zahlen übereinander     
                if (row < numbers.GetLength(0) - 1)
                {
                    if (numbers[row, col] < numbers[row + 1, col])
                    {
                        Console.ForegroundColor = COLOR_LESS;
                        Console.Write("A   ");
                    }
                    else if (numbers[row, col] > numbers[row + 1, col])
                    {
                        Console.ForegroundColor = COLOR_GREATER;
                        Console.Write("V   ");
                    }
                    else
                    {
                        Console.ForegroundColor = COLOR_EQUAL;
                        Console.Write("=   ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
