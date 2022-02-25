/***********************************************************************************************
 * Assignment:     Matrix Calculations
 * Author:             
 * Class:          1AHIF
 * Date:           14.03.2017                              
 * ------------------------------------------------ 
 * Description:      
 * Unit tests and implementation of methods to print, compare,
 * and multiply two-dimensional matrices.
 ***********************************************************************************************/
using System;

namespace MatrixCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Achtung! In diesem Beispiel empfiehlt es sich,
            // als erste Dimension die Anzahl der Zeilen zu nehmen,
            // und als zweite Dimension die Anzahl der Spalten!
            // Also: 
            // int[,] matrix1a = new int[2, 3];
            // => 2 Zeilen, 3 Spalten
            int[,] matrix1a = {
                {3, 2, 1},
                {4, 7, 9}};
            int[,] matrix1b = {
                {2, 8},
                {3, 5},
                {6, 1}};
            int[,] expectedResult1 = {
                {18, 35},
                {83, 76}};

            TestMatrixMultiply(matrix1a, matrix1b, expectedResult1);
            
            int[,] matrix2a = {
                {3, 6, 7},
                {5, 3, 5},
                {6, 2, 9}};
            int[,] matrix2b = {
                {1, 2, 7},
                {0, 9, 3},
                {6, 0, 6}};
            int[,] expectedResult2 = {
                {45, 60, 81},
                {35, 37, 74},
                {60, 30, 102}};

            TestMatrixMultiply(matrix2a, matrix2b, expectedResult2);

            int[,] matrix3a = {
                {4}};
            int[,] matrix3b = {
                {7}};
            int[,] expectedResult3 = {
                {28}};

            TestMatrixMultiply(matrix3a, matrix3b, expectedResult3);
            
            PrintSummary();
            Console.ReadKey();
        }

        /// <summary>
        /// This method receives a matrix A and a matrix B and performs
        /// several test cases on them. Result of matrix multiply must
        /// match the given expectedResult matrix.
        /// </summary>
        /// <param name="matrixA">First matrix</param>
        /// <param name="matrixB">Second matrix</param>
        /// <param name="expectedResult">Expected matrix after multiplication</param>
        private static void TestMatrixMultiply(int[,] matrixA, int[,] matrixB, int[,] expectedResult) 
        {
            Assert(CompareMatrix(matrixA, matrixA), "CompareMatrix: Vergleich identer Matrizen");
            Assert(!CompareMatrix(matrixA, matrixB), "CompareMatrix: Vergleich verschiedener Matrizen");
            int[,] matrixMultiplied = MultiplyMatrix(matrixA, matrixB);
            Assert(CompareMatrix(expectedResult, matrixMultiplied), "Matrixmultipikation richtig");

            PrintMatrix(matrixA);
            Console.WriteLine("*");
            PrintMatrix(matrixB);
            Console.WriteLine("=");
            PrintMatrix(matrixMultiplied);
            Console.WriteLine();
        }

        /// <summary>
        /// A simple printout of the given matrix on the Console.
        /// Numbers in a row are separated by one space character.
        /// </summary>
        /// <param name="matrix">Matrix to print</param>
        private static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine("Hier sollte eine Matrix auf die Console ausgegeben werden.");
        }

        /// <summary>
        /// MatrixA and matrixB are multiplied and the resulting
        /// matrix is returned.
        /// </summary>
        /// <param name="matrixA">Left operand</param>
        /// <param name="matrixB">right operand</param>
        /// <returns>Result of the matrix multiplication</returns>
        static int[,] MultiplyMatrix(int[,] matrixA, int[,] matrixB)
        {
            return new int[0,0];
        }

        /// <summary>
        /// This method returns true, if the matrixA has the same
        /// size and the same content like matrixB.
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns></returns>
        static bool CompareMatrix(int[,] matrixA, int[,] matrixB)
        {
            return false;
        }

        /// <summary>
        /// Assert the specified condition and reports message.
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        /// <param name="message">Message.</param>
        private static void Assert(bool condition, string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            if (condition)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message + " ... OK");
                passCount++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message + " ... Fail");
                failCount++;
            }
            Console.ForegroundColor = originalColor;
        }

        private static void PrintSummary()
        {
            Console.WriteLine("Total number of " + (passCount + failCount) + " test cases");
            Console.WriteLine(passCount + " tests passed");
            Console.WriteLine(failCount + " tests failed");
        }

        private static int passCount;
        private static int failCount;

    }
}
