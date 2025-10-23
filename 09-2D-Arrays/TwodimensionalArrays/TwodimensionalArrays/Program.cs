using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwodimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrixA = new int[3, 4];
            int[,] matrixB = { { 4, 2, 8, 7 }, 
                               { 8, 5, 3, 9 }, 
                               { 2, 2, 5, 5 } };


            Console.WriteLine("Anzahl Zeilen MatrixA: " + matrixA.GetLength(0));
            Console.WriteLine("Anzahl Spalten MatrixA: " + matrixA.GetLength(1));
            PrintMatrix("Matrix A: ", matrixA);

            
            Console.WriteLine("Anzahl Zeilen MatrixB: " + matrixB.GetLength(0));
            Console.WriteLine("Anzahl Spalten MatrixB: " + matrixB.GetLength(1));
            PrintMatrix("Matrix B: ", matrixB);

            matrixA[0, 0] = 1; 
            matrixA[1, 3] = 13;
            matrixA[2, 3] = 23;

            PrintMatrix("Matrix A: ", matrixA);

            Console.ReadKey();

        }

        static void PrintMatrix(string header, int[,] matrix)
        {

            Console.WriteLine(header);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
