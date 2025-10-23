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

        bool showHelp = false;
        bool isExit = false;
        Sudoku.PrintSudoku(sudoku, showHelp);

        while (!Sudoku.IsSudokuComplete(sudoku) && !isExit)
        {
            int col = ReadColOrMenu();
            if (col < 0)
            {
                switch (ShowMenu())
                {
                    case "0": break;
                    case "1":
                        showHelp = !showHelp;
                        Sudoku.PrintSudoku(sudoku, showHelp);
                        break;
                    case "2":
                        sudoku = new int [9, 9];
                        Sudoku.PrintSudoku(sudoku, showHelp);
                        break;
                    case "X":
                        isExit = true;
                        break;
                }
            }
            else
            {
                int row = ReadRow();
                int no = ReadNumber("Number (0 to clear)", 0, 9);

                if (!Sudoku.SetField(sudoku, row, col, no))
                {
                    Console.WriteLine("The number you entered is not valid (at this position)!");
                }

                Sudoku.PrintSudoku(sudoku, showHelp);
            }
        }

        if (Sudoku.IsSudokuComplete(sudoku))
        {
            Console.WriteLine("Congratulations, you did it!");
            Sudoku.PrintSudoku(sudoku, false);
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }

    private static int ReadRow()
    {
        return ReadNumber("Row   ", 1, 9) - 1;
    }

    private static int ReadColOrMenu()
    {
        string input;
        bool isOk;
        do
        {
            Console.Write($"Column [A..I] (or ?): ");
            input = Console.ReadLine().ToUpper();
            isOk = input.Length == 1 && ((input[0] >= 'A' && input[0] <= 'I') || input[0] == '?');
        } while (!isOk);

        return input[0] == '?' ? -1 : input[0] - 'A';
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

    private static string ShowMenu()
    {
        bool isOk;
        string menu;
        do
        {
            Console.WriteLine("0 Continue");
            Console.WriteLine("1 Show/hide help");
            Console.WriteLine("2 Start new game");
            Console.WriteLine("X Exit program");
            Console.Write("=>");
            menu = Console.ReadLine();
            isOk = menu.Length == 1;
        } while (!isOk);

        return menu.ToUpper();
    }
}