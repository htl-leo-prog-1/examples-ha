/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: MatrixCalculation
*--------------------------------------------------------------
*/

using Microsoft.VisualBasic;

namespace MatrixCalculations
{
    using System;

    public class Matrix
    {
        public static void Print(int[,] matrix)
        {
            if (matrix == null)
            {
                Console.WriteLine("print nicht möglich!");
                return;
            }

            foreach (var line in ToStrings(matrix))
            {
                Console.WriteLine(line);
            }
        }

        public static string[] ToStrings(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int min;
            int max;

            GetMinMaxValue(matrix,out min, out max);

            var result = new string[rows];

            int fieldSize = Math.Max(min.ToString().Length, max.ToString().Length);

            for (var row = 0; row < rows; row++)
            {
                result[row] = string.Empty;

                for (var col = 0; col < cols; col++)
                {
                    if (col > 0)
                    {
                        result[row] += " ";
                    }

                    result[row] += matrix[row, col].ToString().PadLeft(fieldSize);
                }
            }

            return result;
        }

        private static void GetMinMaxValue(int[,] matrix, out int min, out int max)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            min = int.MaxValue;
            max = int.MinValue;

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    var val = matrix[row, col];
                    if (val < min)
                    {
                        min = val;
                    }
                    if (val > max)
                    {
                        max = val;
                    }
                }
            }
        }

        public static int[,] Multiply(int[,] matrixA, int[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            if (colsA != rowsB)
            {
                return null;
            }

            var multiplied = new int[rowsA, colsB];

            for (int row = 0; row < rowsA; row++)
            {
                for (int col = 0; col < colsB; col++)
                {
                    multiplied[row, col] = MultiplyPosition(matrixA, matrixB, colsA, row, col);
                }
            }

            return multiplied;
        }

        public static int MultiplyPosition(int[,] matrixA, int[,] matrixB, int size, int row, int col)
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrixA[row, i] * matrixB[i, col];
            }

            return sum;
        }

        public static bool Compare(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA == matrixB)
            {
                return true;
            }

            if (matrixA == null || matrixB == null)
            {
                return false;
            }

            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            if (rowsA != rowsB || colsA != colsB)
            {
                return false;
            }

            for (int row = 0; row < rowsA; row++)
            {
                for (int col = 0; col < colsB; col++)
                {
                    if (matrixA[row, col] != matrixB[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static int[,] RotateCounterclockwise(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            var newMatrix = new int[cols, rows];

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    newMatrix[cols - col - 1, row] = matrix[row, col];
                }
            }

            return newMatrix;
        }

        public static int[,] RotateClockwise(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            var newMatrix = new int[cols, rows];

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    newMatrix[col, rows - row - 1] = matrix[row, col];
                }
            }

            return newMatrix;
        }

        public static int[,] MirrorHorizontal(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            var newMatrix = new int[rows, cols];

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    newMatrix[rows - row - 1, col] = matrix[row, col];
                }
            }

            return newMatrix;
        }

        public static int[,] MirrorVertical(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            var newMatrix = new int[rows, cols];

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    newMatrix[row, cols - col - 1] = matrix[row, col];
                }
            }

            return newMatrix;
        }
    }
}