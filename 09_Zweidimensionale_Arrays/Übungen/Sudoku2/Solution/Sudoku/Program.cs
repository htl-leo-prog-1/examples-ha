/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Sudoku with UnitTests
*--------------------------------------------------------------
*/

using System;

namespace Sudoku;

class Program
{
    static void Main(string[] args)
    {
        //        int[,] sudoku = new int [9, 9];
        int[,] sudoku = new int[,]
        {
            {0, 0, 1, 2, 0, 0, 8, 7, 0},
            {0, 0, 6, 0, 8, 0, 0, 2, 4},
            {0, 8, 0, 0, 7, 3, 0, 0, 5},
            {6, 2, 0, 1, 3, 0, 0, 8, 0},
            {8, 0, 0, 9, 4, 0, 0, 5, 2},
            {5, 9, 4, 0, 0, 8, 3, 0, 6},
            {3, 0, 9, 0, 0, 0, 5, 4, 0},
            {1, 0, 0, 0, 9, 0, 2, 0, 8},
            {0, 0, 0, 0, 5, 7, 0, 0, 0}
        };

        Sudoku.PrintSudoku(sudoku);

        while (!Sudoku.IsSudokuComplete(sudoku))
        {
            int col;
            int row;
            int no;

            EnterNumber(out row, out col, out no);

            if (!Sudoku.SetField(sudoku, row, col, no))
            {
                Console.WriteLine("The number you entered is not valid (at this position)!");
            }

            Sudoku.PrintSudoku(sudoku);
        }

        if (Sudoku.IsSudokuComplete(sudoku))
        {
            Console.WriteLine("Congratulations, you did it!");
            Sudoku.PrintSudoku(sudoku);
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }

    private static bool EnterNumber(out int row, out int col, out int no)
    {
        col = ReadCol();
        row = ReadRow();
        no = ReadNumber("Number (0 to clear)", 0, 9);
        return true;
    }

    private static int ReadRow()
    {
        return ReadNumber("Row   ", 1, 9) - 1;
    }

    private static int ReadCol()
    {
        string input;
        bool isOk;
        do
        {
            Console.Write($"Column [A..G]: ");
            input = Console.ReadLine().ToUpper();
            isOk = input.Length == 1 && input[0] >= 'A' && input[0] <= 'G';
        } while (!isOk);

        return input[0] - 'A';
    }

    private static int ReadNumber(string message, int min, int max)
    {
        int number;
        bool isOk;
        do
        {
            Console.Write($"{message} [{min}..{max}]: ");
            isOk = int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
        } while (!isOk);

        return number;
    }
}