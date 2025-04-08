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

    public class Program
    {
        public static void Main()
        {
            int[,] matrixA =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 99 }
            };

            int[,] matrixB =
            {
                { 11, 12, 13 },
                { 24, 25, 26 },
                { 37, 38, 39 }
            };


            MatrixTools.Print(matrixA);
            Console.WriteLine("+");
            MatrixTools.Print(matrixB);
            Console.WriteLine("=");
            int[,] resultAdd = MatrixTools.Add(matrixA, matrixB);
            MatrixTools.Print(resultAdd);

            Console.WriteLine();
            int[] distinct = MatrixTools.Distinct(resultAdd);

            Console.WriteLine($"Distinct numbers: {string.Join(',',distinct)}");
        }
    }
}