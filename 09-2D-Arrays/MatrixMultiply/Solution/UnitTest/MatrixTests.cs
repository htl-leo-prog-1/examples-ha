/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Matrixtest UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest
{
    using FluentAssertions;
    using MatrixCalculations;
    using Xunit;

    public class MatrixTests
    {
        private void TestMatrixMultiply(int[,] matrixA, int[,] matrixB, int[,] expectedResult)
        {
            Matrix.CompareMatrix(matrixA, matrixA).Should().BeTrue("CompareMatrix: Vergleich identer Matrizen");
            Matrix.CompareMatrix(matrixA, matrixB).Should().BeFalse("CompareMatrix: Vergleich verschiedener Matrizen");
            var matrixMultiplied = Matrix.MultiplyMatrix(matrixA, matrixB);
            Matrix.CompareMatrix(expectedResult, matrixMultiplied).Should().BeTrue("Matrixmultipikation richtig");
        }
        [Fact]
        public void T01_Multiply()
        {
            int[,] matrix1a =
            {
                {3, 2, 1},
                {4, 7, 9}
            };
            int[,] matrix1b =
            {
                {2, 8},
                {3, 5},
                {6, 1}
            };
            int[,] expectedResult1 =
            {
                {18, 35},
                {83, 76}
            };

            TestMatrixMultiply(matrix1a, matrix1b, expectedResult1);

        }

        [Fact]
        public void T02_Multiply()
        {
            int[,] matrix2a =
            {
                {3, 6, 7},
                {5, 3, 5},
                {6, 2, 9}
            };
            int[,] matrix2b =
            {
                {1, 2, 7},
                {0, 9, 3},
                {6, 0, 6}
            };
            int[,] expectedResult2 =
            {
                {45, 60, 81},
                {35, 37, 74},
                {60, 30, 102}
            };

            TestMatrixMultiply(matrix2a, matrix2b, expectedResult2);
        }

        [Fact]
        public void T03_Multiply()
        {
            int[,] matrix3a =
            {
                {4}
            };
            int[,] matrix3b =
            {
                {7}
            };
            int[,] expectedResult3 =
            {
                {28}
            };

            TestMatrixMultiply(matrix3a, matrix3b, expectedResult3);
        }
    }
}