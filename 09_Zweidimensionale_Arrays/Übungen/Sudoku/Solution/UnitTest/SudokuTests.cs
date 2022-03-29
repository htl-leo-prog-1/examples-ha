/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-MK
*--------------------------------------------------------------
* Description: Sudoku UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;
    using Sudoku;

    public class SudokuTests
    {
        [Theory]
        [MemberData(nameof(SetNumberDryRunData))]
        public void SetNumberDryRun(int[,] sudoku, int[] number, bool possible)
        {
            int[,] modifiedArray = Sudoku.SetNumberDryRun(sudoku, number);

            modifiedArray.Should().NotBe(sudoku, "has to be a copy");

            if (!possible)
            {
                CompareJaggedArrays(Sudoku.GetRowsAndColumns(modifiedArray),
                    Sudoku.GetRowsAndColumns(sudoku));
                return;
            }

            int row = number[0] - 1;
            int col = number[1] - 1;
            modifiedArray[row, col].Should().Be(number[2]);
            sudoku[row, col].Should().NotBe(number[2]);
        }

        [Theory]
        [MemberData(nameof(SetNumberData))]
        public void SetNumber(int[,] sudoku, int[] number, bool e)
        {
            bool success = Sudoku.SetNumber(sudoku, number);

            success.Should().Be(e);

            int row = number[0] - 1;
            int col = number[1] - 1;
            if (success)
            {
                Action verify = () => { sudoku[row, col].Should().Be(number[2]); };
                verify.Should().NotThrow();
                return;
            }

            Action access = () =>
            {
                int _ = sudoku[row, col];
            };
            access.Should().Throw<IndexOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(SudokuCompleteData))]
        public void IsSudokuComplete(int[,] sudoku, bool expected)
        {
            bool complete = Sudoku.IsSudokuComplete(sudoku);

            complete.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SudokuValidData))]
        public void IsSudokuValid(int[,] sudoku, bool expected)
        {
            bool valid = Sudoku.IsSudokuValid(sudoku);

            valid.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(CheckSudokuData))]
        public void CheckSudoku(int[,] sudoku, bool checkValid, bool expected)
        {
            bool result = Sudoku.CheckSudoku(sudoku, checkValid);

            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(RowsAndColsData))]
        public void GetRowsAndColumns(int[,] sudoku, int[][] expected)
        {
            int[][] rowsAndCols = Sudoku.GetRowsAndColumns(sudoku);

            rowsAndCols.Should().NotBeNullOrEmpty()
                .And.HaveCount(expected.Length);
            CompareJaggedArrays(rowsAndCols, expected);
        }

        [Theory]
        [MemberData(nameof(SegmentValidData))]
        public void IsSegmentValid(int[,] sudoku, int startRow, int startColumn, int sideLength, bool e)
        {
            bool valid = Sudoku.IsSegmentValid(sudoku, startRow, startColumn, sideLength);

            valid.Should().Be(e);
        }

        [Theory]
        [MemberData(nameof(SegmentCompleteData))]
        public void IsSegmentComplete(int[,] sudoku, int startRow, int startColumn, int sideLength, bool e)
        {
            bool complete = Sudoku.IsSegmentComplete(sudoku, startRow, startColumn, sideLength);

            complete.Should().Be(e);
        }

        [Theory]
        [MemberData(nameof(SegmentNumbersData))]
        public void GetNumbersInSegment(int[,] sudoku, int startRow, int startColumn, int sideLength, int[] expected)
        {
            int[] numbers = Sudoku.GetNumbersInSegment(sudoku, startRow, startColumn, sideLength);

            numbers.Should().NotBeNullOrEmpty()
                .And.BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(9)]
        public void CreateArrayToContainSegmentNumbers(int l)
        {
            int[] array = Sudoku.CreateArrayToContainSegmentNumbers(l);

            array.Should().NotBeNull()
                .And.HaveCount(l * l)
                .And.OnlyContain(i => i == default);
        }

        [Fact]
        public void CreateArrayToContainSegmentNumbers_Zero()
        {
            int[] array = Sudoku.CreateArrayToContainSegmentNumbers(0);

            array.Should().NotBeNull()
                .And.BeEmpty();
        }

        [Theory]
        [InlineData(new[] {1, 2, 3, 4}, true)]
        [InlineData(new[] {1, 2, 3, 0}, false)]
        [InlineData(new[] {0, 1, 2}, false)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, true)]
        [InlineData(new[] {1, 2, 3, 4, 4, 6, 7, 8, 9}, false)]
        [InlineData(new[] {1, 2, 3, 4, 0, 6, 7, 8, 9}, false)]
        [InlineData(new[] {1, 0, 3, 4, 0, 6, 7, 8, 9}, false)]
        [InlineData(new[] {0, 0, 0, 0, 0, 0, 0, 0, 0}, false)]
        public void IsSequenceComplete(int[] s, bool e)
        {
            bool complete = Sudoku.IsSequenceComplete(s);

            complete.Should().Be(e);
        }

        [Theory]
        [InlineData(new[] {1, 2, 3}, true)]
        [InlineData(new[] {1, 2, 3, 55, -6}, false)]
        [InlineData(new[] {1, 2, 2}, false)]
        [InlineData(new[] {1, 2, 3, 4, 1}, false)]
        [InlineData(new[] {1, 2, 3, 4, 0}, true)]
        [InlineData(new[] {1, 2, 3, 4, 0, 0}, true)]
        [InlineData(new[] {1, 2, 3, 4, 0, 0, 1}, false)]
        [InlineData(new[] {0, 1, 2, 3, 4, 0, 0}, true)]
        public void IsSequenceValid(int[] s, bool e)
        {
            bool valid = Sudoku.IsSequenceValid(s);

            valid.Should().Be(e);
        }

        [Theory]
        [InlineData(new[] {1, 2, 3}, 2, true)]
        [InlineData(new[] {1, 2, 3}, 4, false)]
        [InlineData(new[] {1, 2, 3}, 0, false)]
        [InlineData(new[] {0, 2, 3}, 0, false)]
        [InlineData(new[] {2, 3, -4, 55}, 8, false)]
        [InlineData(new[] {2, 3, -4, 55}, -4, true)]
        public void ContainsExceptZero(int[] a, int n, bool e)
        {
            bool contained = Sudoku.ContainsExceptZero(a, n);

            contained.Should().Be(e);
        }

        private static readonly int[,] validIncompleteSudoku =
        {
            {2, 0, 9, 7, 0, 0, 5, 0, 0},
            {0, 0, 4, 0, 9, 0, 1, 0, 0},
            {0, 8, 0, 0, 3, 0, 4, 7, 0},
            {0, 2, 6, 0, 0, 1, 3, 0, 5},
            {0, 5, 0, 0, 0, 0, 0, 2, 0},
            {4, 0, 3, 0, 5, 0, 0, 9, 1},
            {0, 0, 7, 0, 0, 3, 0, 5, 0},
            {3, 0, 2, 0, 1, 5, 0, 8, 7},
            {5, 0, 8, 4, 2, 7, 9, 0, 0}
        };

        private static readonly int[,] invalidIncompleteSudoku =
        {
            {2, 0, 9, 7, 0, 0, 5, 0, 1},
            {0, 2, 4, 0, 9, 0, 1, 0, 0},
            {0, 8, 0, 0, 3, 0, 4, 7, 0},
            {0, 2, 6, 0, 4, 1, 3, 4, 5},
            {2, 5, 0, 5, 0, 5, 0, 2, 0},
            {4, 0, 3, 0, 5, 0, 0, 9, 1},
            {0, 1, 7, 1, 0, 3, 0, 5, 0},
            {3, 0, 2, 0, 1, 5, 0, 8, 7},
            {5, 0, 8, 4, 2, 7, 9, 0, 0}
        };

        private static readonly int[,] validCompleteSudoku =
        {
            {5, 3, 4, 6, 7, 8, 9, 1, 2},
            {6, 7, 2, 1, 9, 5, 3, 4, 8},
            {1, 9, 8, 3, 4, 2, 5, 6, 7},
            {8, 5, 9, 7, 6, 1, 4, 2, 3},
            {4, 2, 6, 8, 5, 3, 7, 9, 1},
            {7, 1, 3, 9, 2, 4, 8, 5, 6},
            {9, 6, 1, 5, 3, 7, 2, 8, 4},
            {2, 8, 7, 4, 1, 9, 6, 3, 5},
            {3, 4, 5, 2, 8, 6, 1, 7, 9}
        };

        private static void CompareJaggedArrays(int[][] a, int[][] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i].Should().BeEquivalentTo(b[i]);
            }
        }

        public static IEnumerable<object[]> SetNumberDryRunData =>
            new[]
            {
                new object[]
                {
                    new[,]
                    {
                        {1, 2, 3},
                        {4, 5, 6},
                        {7, 8, 9}
                    },
                    new[] {2, 2, 2}, true
                },
                new object[]
                {
                    new[,]
                    {
                        {1, 2, 3},
                        {4, 5, 6},
                        {7, 8, 9}
                    },
                    new[] {4, 2, 2}, false
                }
            };

        public static IEnumerable<object[]> SetNumberData =>
            new[]
            {
                new object[]
                {
                    new[,]
                    {
                        {1, 2, 3},
                        {4, 5, 6},
                        {7, 8, 9}
                    },
                    new[] {4, 2, -1}, false
                },
                new object[]
                {
                    new[,]
                    {
                        {1, 2, 3},
                        {4, 5, 6},
                        {7, 8, 9}
                    },
                    new[] {1, 0, -1}, false
                },
                new object[]
                {
                    new[,]
                    {
                        {1, 2, 3},
                        {4, 5, 6},
                        {7, 8, 9}
                    },
                    new[] {0, 2, -1}, false
                },
                new object[]
                {
                    new[,]
                    {
                        {1, 2, 3},
                        {4, 5, 6},
                        {7, 8, 9}
                    },
                    new[] {2, 4, -1}, false
                },
                new object[]
                {
                    new[,]
                    {
                        {1, 2, 3},
                        {4, 5, 6},
                        {7, 8, 9}
                    },
                    new[] {2, 2, 7}, true
                },
                new object[]
                {
                    new[,]
                    {
                        {1, 2, 3},
                        {4, 5, 6},
                        {7, 8, 9}
                    },
                    new[] {1, 1, 4}, true
                },
                new object[]
                {
                    new[,]
                    {
                        {1, 2, 3},
                        {4, 5, 6},
                        {7, 8, 9}
                    },
                    new[] {3, 3, 1}, true
                },
                new object[]
                {
                    new[,]
                    {
                        {1, 2, 3, 4},
                        {4, 5, 6, 5},
                        {7, 8, 9, 6},
                        {9, 8, 7, 7}
                    },
                    new[] {4, 4, 8}, true
                }
            };

        public static IEnumerable<object[]> SudokuCompleteData =>
            new[]
            {
                new object[] {validCompleteSudoku, true},
                new object[] {validIncompleteSudoku, false}
            };

        public static IEnumerable<object[]> SudokuValidData =>
            new[]
            {
                new object[] {validCompleteSudoku, true},
                new object[] {validIncompleteSudoku, true},
                new object[] {invalidIncompleteSudoku, false}
            };

        public static IEnumerable<object[]> CheckSudokuData =>
            new[]
            {
                new object[] {validCompleteSudoku, true, true},
                new object[] {validCompleteSudoku, false, true},
                new object[] {validIncompleteSudoku, true, true},
                new object[] {validIncompleteSudoku, false, false},
                new object[] {invalidIncompleteSudoku, true, false},
                new object[] {invalidIncompleteSudoku, false, false}
            };

        public static IEnumerable<object[]> SegmentNumbersData =>
            new[]
            {
                new object[] {validCompleteSudoku, 0, 0, 3, new[] {5, 3, 4, 6, 7, 2, 1, 9, 8}},
                new object[] {validCompleteSudoku, 3, 3, 3, new[] {7, 6, 1, 8, 5, 3, 9, 2, 4}},
                new object[] {validCompleteSudoku, 6, 6, 3, new[] {2, 8, 4, 6, 3, 5, 1, 7, 9}},
                new object[] {validIncompleteSudoku, 6, 0, 3, new[] {0, 0, 7, 3, 0, 2, 5, 0, 8}},
                new object[] {validIncompleteSudoku, 3, 6, 3, new[] {3, 0, 5, 0, 2, 0, 0, 9, 1}},
                new object[] {validIncompleteSudoku, 1, 1, 2, new[] {0, 4, 8, 0}}
            };

        public static IEnumerable<object[]> SegmentCompleteData =>
            new[]
            {
                new object[] {validCompleteSudoku, 3, 3, 3, true},
                new object[] {validIncompleteSudoku, 3, 3, 3, false},
            };

        public static IEnumerable<object[]> SegmentValidData =>
            new[]
            {
                new object[] {validCompleteSudoku, 3, 3, 3, true},
                new object[] {validIncompleteSudoku, 3, 3, 3, true},
                new object[] {invalidIncompleteSudoku, 0, 0, 3, false},
                new object[] {invalidIncompleteSudoku, 3, 3, 3, false}
            };

        public static IEnumerable<object[]> RowsAndColsData =>
            new[]
            {
                new object[]
                {
                    validCompleteSudoku, new[]
                    {
                        new[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                        new[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                        new[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
                        new[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
                        new[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                        new[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
                        new[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                        new[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                        new[] {3, 4, 5, 2, 8, 6, 1, 7, 9},
                        new[] {5, 6, 1, 8, 4, 7, 9, 2, 3},
                        new[] {3, 7, 9, 5, 2, 1, 6, 8, 4},
                        new[] {4, 2, 8, 9, 6, 3, 1, 7, 5},
                        new[] {6, 1, 3, 7, 8, 9, 5, 4, 2},
                        new[] {7, 9, 4, 6, 5, 2, 3, 1, 8},
                        new[] {8, 5, 2, 1, 3, 4, 7, 9, 6},
                        new[] {9, 3, 5, 4, 7, 8, 2, 6, 1},
                        new[] {1, 4, 6, 2, 9, 5, 8, 3, 7},
                        new[] {2, 8, 7, 3, 1, 6, 4, 5, 9}
                    }
                },
                new object[]
                {
                    invalidIncompleteSudoku, new[]
                    {
                        new[] {2, 0, 9, 7, 0, 0, 5, 0, 1},
                        new[] {0, 2, 4, 0, 9, 0, 1, 0, 0},
                        new[] {0, 8, 0, 0, 3, 0, 4, 7, 0},
                        new[] {0, 2, 6, 0, 4, 1, 3, 4, 5},
                        new[] {2, 5, 0, 5, 0, 5, 0, 2, 0},
                        new[] {4, 0, 3, 0, 5, 0, 0, 9, 1},
                        new[] {0, 1, 7, 1, 0, 3, 0, 5, 0},
                        new[] {3, 0, 2, 0, 1, 5, 0, 8, 7},
                        new[] {5, 0, 8, 4, 2, 7, 9, 0, 0},
                        new[] {2, 0, 0, 0, 2, 4, 0, 3, 5},
                        new[] {0, 2, 8, 2, 5, 0, 1, 0, 0},
                        new[] {9, 4, 0, 6, 0, 3, 7, 2, 8},
                        new[] {7, 0, 0, 0, 5, 0, 1, 0, 4},
                        new[] {0, 9, 3, 4, 0, 5, 0, 1, 2},
                        new[] {0, 0, 0, 1, 5, 0, 3, 5, 7},
                        new[] {5, 1, 4, 3, 0, 0, 0, 0, 9},
                        new[] {0, 0, 7, 4, 2, 9, 5, 8, 0},
                        new[] {1, 0, 0, 5, 0, 1, 0, 7, 0}
                    }
                },
                new object[]
                {
                    new[,]
                    {
                        {1, 2, 3},
                        {4, 5, 6},
                        {7, 8, 9}
                    },
                    new[]
                    {
                        new[] {1, 2, 3},
                        new[] {4, 5, 6},
                        new[] {7, 8, 9},
                        new[] {1, 4, 7},
                        new[] {2, 5, 8},
                        new[] {3, 6, 9}
                    }
                }
            };
    }
}