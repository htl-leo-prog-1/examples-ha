/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: MatrixCalculation
*--------------------------------------------------------------
*/

namespace MatrixCalculations
{
    using System;

    public class Matrix
    {
        public static void PrintMatrix(int[,] matrix)
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

        public static int[,] MultiplyMatrix(int[,] matrixA, int[,] matrixB)
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

        public static int MultiplyPosition(int[,] matrix1, int[,] matrix2, int size, int row, int col)
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix1[row, i] * matrix2[i, col];
            }

            return sum;
        }

        public static bool CompareMatrix(int[,] matrix1, int[,] matrix2)
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
    }
}