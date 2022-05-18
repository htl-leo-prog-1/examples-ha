/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: MatrixCalculation
*--------------------------------------------------------------
*/


using System;
using MatrixCalculations;

int[,] matrixA =
{
    {3, 6, 7},
    {5, 3, 5},
    {6, 2, 9}
};

int[,] matrixB =
{
    {1, 2, 7},
    {0, 9, 3},
    {6, 0, 6}
};

int[,] matrixC =
{
    {1, 2, 3, 4},
    {5, 6, 7, 8},
    {9, 10, 11, 12}
};


Matrix.Print(matrixA);
Console.WriteLine("*");
Matrix.Print(matrixB);
Console.WriteLine("=");
Matrix.Print(Matrix.Multiply(matrixA, matrixB));
Console.WriteLine();

Matrix.Print(matrixC);
Console.WriteLine("rotate clockwise");
var matrix = Matrix.RotateClockwise(matrixC);
Matrix.Print(matrix);
Console.WriteLine("rotate counterclockwise");
matrix = Matrix.RotateCounterclockwise(matrix);
Matrix.Print(matrix);

Console.WriteLine("mirror horizontal");
matrix = Matrix.MirrorHorizontal(matrix);
Matrix.Print(matrix);

Console.WriteLine("mirror vertical");
matrix = Matrix.MirrorVertical(matrix);
Matrix.Print(matrix);
