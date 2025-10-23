/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: MatrixCalculation
*--------------------------------------------------------------
*/

namespace Matrix
{
    using System;

    public class MatrixTools
    {
        public static void Print(int[,] matrix)
        {
            if (matrix == null)
            {
                Console.WriteLine("print nicht möglich!");
                return;
            }

            int rows         = matrix.GetLength(0);
            int cols         = matrix.GetLength(1);

            int    numberLength       = GetMaxNumberLength(matrix);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (col != 0)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(string.Format($"{{0,{numberLength}:D}}", matrix[row,col]));
                }
                Console.WriteLine();
            }
        }

        private static int GetMaxNumberLength(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int min = int.MaxValue;
            int max = int.MinValue;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
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

            return Math.Max(min.ToString().Length, max.ToString().Length);
        }


        public static int[] Distinct(int[,] matrix)
        {
            int[] result = new int[matrix.GetLength(0) * matrix.GetLength(1)];
            int   count  = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    if (!Contains(result, matrix[row, col], count))
                    {
                        result[count] = matrix[row, col];
                        count++;
                    }
                }
            }

            return Copy(result, count);
        }

        public static int[,] Add(int[,] matrixA, int[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            if (colsA != colsB || rowsA != rowsB)
            {
                return null;
            }

            int[,] added = new int[rowsA, colsB];

            for (int row = 0; row < rowsA; row++)
            {
                for (int col = 0; col < colsB; col++)
                {
                    added[row, col] = matrixA[row,col] + matrixB[row,col];
                }
            }

            return added;
        }

        private static bool Contains(int[] numbers, int value, int length)
        {
            length = Math.Min(length, numbers.Length);

            for (int i = 0; i < length; i++)
            {
                if (numbers[i] == value)
                {
                    return true;
                }
            }

            return false;
        }
        private static int[] Copy(int[] ar, int length)
        {
            int[] newNumbers = new int[length];

            for (int i = 0; i < Math.Min(length, ar.Length); i++)
            {
                newNumbers[i] = ar[i];
            }

            return newNumbers;
        }
    }
}