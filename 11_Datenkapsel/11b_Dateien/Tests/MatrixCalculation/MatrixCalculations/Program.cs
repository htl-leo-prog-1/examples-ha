using System;

namespace MatrixCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
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

            int[,] matrix4a = {
                {3, 6, 7},
                {5, 3, 5},
                {6, 2, 9}};
            int[,] matrix4b = {
                {1, 2, 7},
                {0, 9, 3},
                {6, 0, 6},
                {8, 4, 3}};
            int[,] expectedResult4 = null;
            TestMatrixMultiply(matrix4a, matrix4b, expectedResult4);
            
            PrintSummary();
            Console.ReadKey();
        }

        private static void TestMatrixMultiply(int[,] matrixA, int[,] matrixB, int[,] expectedResult) 
        {
            Assert(CompareMatrix(matrixA, matrixA), "CompareMatrix: Vergleich identer Matrizen");
            Assert(!CompareMatrix(matrixA, matrixB), "CompareMatrix: Vergleich verschiedener Matrizen");
            int[,] matrixMultiplied = MultiplyMatrix(matrixA, matrixB);
            Assert(CompareMatrix(expectedResult, matrixMultiplied), "Multiplikationsergebnis richtig");

            PrintMatrix(matrixA);
            Console.WriteLine("*");
            PrintMatrix(matrixB);
            Console.WriteLine("=");
            PrintMatrix(matrixMultiplied);
            Console.WriteLine();
        }

        private static void PrintMatrix(int[,] matrix)
        {
            if (matrix == null)
            {
                Console.WriteLine("Multiplikation nicht möglich!");
                return;
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] MultiplyMatrix(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA.GetLength(1) != matrixB.GetLength(0))
            {
                return null;
            }
            int rows = matrixA.GetLength(0);
            int cols = matrixB.GetLength(1);
            int[,] multiplied = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    multiplied[row, col] = 
                        MultiplyPosition(matrixA, matrixB, 
                            matrixA.GetLength(1), row, col);
                }
            }
            return multiplied;
        }

        static int MultiplyPosition(int[,] matrix1, int[,] matrix2, int size, int row, int col)
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix1[row, i] * matrix2[i, col];
            }
            return sum;
        }

        static bool CompareMatrix(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1 == matrix2)
            {
                return true;
            }
            if (matrix1 == null || matrix2 == null)
            {
                return false;
            }
            if (matrix1.GetLength(0) != matrix2.GetLength(0) ||
                matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                return false;
            }
            for (int row = 0; row < matrix1.GetLength(0); row++)
            {
                for (int col = 0; col < matrix1.GetLength(1); col++)
                {
                    if (matrix1[row, col] != matrix2[row, col])
                    {
                        return false;
                    }
                }
            }
            return true;
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
