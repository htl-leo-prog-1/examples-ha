/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: MatrixAdd UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest
{
    using FluentAssertions;

    using Matrix;

    using Xunit;

    public class MatrixAddTests
    {
        public bool Compare(int[,] matrixA, int[,] matrixB)
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
        private void TestMatrixAdd(int[,] matrixA, int[,] matrixB, int[,] expectedResult)
        {
            Compare(matrixA, matrixA).Should().BeTrue("Compare: Vergleich identer Matrizen");
            Compare(matrixB, matrixB).Should().BeTrue("Compare: Vergleich identer Matrizen");
            var matrixMultiplied = MatrixTools.Add(matrixA, matrixB);
            Compare(expectedResult, matrixMultiplied).Should().BeTrue("Matrixmultipikation richtig");
        }

        [Fact]
        public void T01_Add()
        {
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

            int[,] expectedResult =
            {
                {4, 8, 14},
                {5, 12, 8},
                {12, 2, 15},
            };

            TestMatrixAdd(matrixA, matrixB, expectedResult);
        }

        [Fact]
        public void T02_Add()
        {
            int[,] matrix2a =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            int[,] matrix2b =
            {
                { 11, 12, 13 },
                { 24, 25, 26 },
                { 37, 38, 39 }
            };

            int[,] expectedResult2 =
            {
                { 12, 14, 16 },
                { 28, 30, 32 },
                { 44, 46, 48 }
            };



            TestMatrixAdd(matrix2a, matrix2b, expectedResult2);
        }

        [Fact]
        public void T03_Add()
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
                {11}
            };

            TestMatrixAdd(matrix3a, matrix3b, expectedResult3);
        }

        [Fact]
        public void T04_Add()
        {
            int[,] matrix =
            {
                {1}
            };
            int[,] expectedResult =
            {
                {2}
            };

            TestMatrixAdd(matrix, matrix, expectedResult);
        }

        [Fact]
        public void T05_Add()
        {
            int[,] matrix =
            {
                {0}
            };

            TestMatrixAdd(matrix, matrix, matrix);
        }

        [Fact]
        public void T06_AddFail()
        {
            int[,] matrixA =
            {
                {4}
            };
            int[,] matrixB =
            {
                {7,2}
            };

            MatrixTools.Add(matrixA,matrixB).Should().BeNull();
        }

        [Fact]
        public void T07_AddFail()
        {
            int[,] matrixA =
            {
                {4}
            };
            int[,] matrixB =
            {
                {7},
                {2}
            };

            MatrixTools.Add(matrixA, matrixB).Should().BeNull();
        }

    }
}