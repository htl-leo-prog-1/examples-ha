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
            Matrix.Compare(matrixA, matrixA).Should().BeTrue("Compare: Vergleich identer Matrizen");
            Matrix.Compare(matrixA, matrixB).Should().BeFalse("Compare: Vergleich verschiedener Matrizen");
            var matrixMultiplied = Matrix.Multiply(matrixA, matrixB);
            Matrix.Compare(expectedResult, matrixMultiplied).Should().BeTrue("Matrixmultipikation richtig");
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

        [Fact]
        public void T04_RotateCounterclockwise()
        {
            int[,] matrix =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
                {10, 11, 12},
                {13, 14, 15}
            };
            int[,] expectedResult =
            {
                {3, 6, 9, 12, 15},
                {2, 5, 8, 11, 14},
                {1, 4, 7, 10, 13}
            };

            var rotated = Matrix.RotateCounterclockwise(matrix);
            rotated.Should().BeEquivalentTo(expectedResult);

            Matrix.RotateClockwise(rotated).Should().BeEquivalentTo(matrix);
        }

        [Fact]
        public void T05_RotateClockwise()
        {
            int[,] matrix =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
                {10, 11, 12},
                {13, 14, 15}
            };
            int[,] expectedResult =
            {
                {13, 10, 7, 4, 1},
                {14, 11, 8, 5, 2},
                {15, 12, 9, 6, 3}
            };

            var rotated = Matrix.RotateClockwise(matrix);
            rotated.Should().BeEquivalentTo(expectedResult);

            Matrix.RotateCounterclockwise(rotated).Should().BeEquivalentTo(matrix);
        }

        [Fact]
        public void T06_MirrorHorizontal()
        {
            int[,] matrix =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
                {10, 11, 12},
                {13, 14, 15}
            };
            int[,] expectedResult =
            {
                {13, 14, 15},
                {10, 11, 12},
                {7, 8, 9},
                {4, 5, 6},
                {1, 2, 3},
            };

            var mirrored = Matrix.MirrorHorizontal(matrix);
            mirrored.Should().BeEquivalentTo(expectedResult);

            Matrix.MirrorHorizontal(mirrored).Should().BeEquivalentTo(matrix);
        }

        [Fact]
        public void T06_MirrorVertical()
        {
            int[,] matrix =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
                {10, 11, 12},
                {13, 14, 15}
            };
            int[,] expectedResult =
            {
                {3, 2, 1},
                {6, 5, 4},
                {9, 8, 7},
                {12, 11, 10},
                {15, 14, 13}
            };

            var mirrored = Matrix.MirrorVertical(matrix);
            mirrored.Should().BeEquivalentTo(expectedResult);

            Matrix.MirrorVertical(mirrored).Should().BeEquivalentTo(matrix);
        }

        [Fact]
        public void T07a_ToString()
        {
            int[,] matrix =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
                {10, 11, 12},
                {13, 14, 99}
            };
            string[] expectedResult =
            {
                " 1  2  3",
                " 4  5  6",
                " 7  8  9",
                "10 11 12",
                "13 14 99"
            };

            var toString = Matrix.ToStrings(matrix);
            toString.Should().BeEquivalentTo(expectedResult);

        }
        [Fact]
        public void T07b_ToString()
        {
            int[,] matrix =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
                {10, 11, 12},
                {13, 14, -1000}
            };
            string[] expectedResult =
            {
                "    1     2     3",
                "    4     5     6",
                "    7     8     9",
                "   10    11    12",
                "   13    14 -1000"
            };

            var toString = Matrix.ToStrings(matrix);
            toString.Should().BeEquivalentTo(expectedResult);

        }
    }
}