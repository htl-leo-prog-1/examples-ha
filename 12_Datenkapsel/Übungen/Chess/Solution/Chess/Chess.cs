/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: ChessGame
*--------------------------------------------------------------
*/

namespace Chess
{
    using System;
    using System.IO;

    public static class Chess
    {
        /// <summary>
        /// Read all chessPieces from a csv file into an array of "ChessPiece". 
        /// </summary>
        /// <param name="fileName">Csv file-name</param>
        /// <returns>The array or "ChessPiece".</returns>
        public static ChessPiece[] ReadFromCsv(string fileName)
        {
            var lines       = File.ReadAllLines(fileName);
            var chessPieces = new ChessPiece[lines.Length - 1]; // -1 because of header

            for (int i = 1; i < lines.Length; i++)
            {
                chessPieces[i - 1] = ReadChessPieceFromCsvLine(lines[i]);
            }

            return chessPieces;
        }

        public static ChessPiece ReadChessPieceFromCsvLine(string line)
        {
            var cols = line.Split(';');
            var chessPiece = new ChessPiece();

            chessPiece.Col = (int)(cols[0][0] - 'A');
            chessPiece.Row = (int)(cols[0][1] - '1');
            chessPiece.Type = cols[1] switch
            {
                "P"  => 6,
                "K"  => 1,
                "Q"  => 2,
                "R"  => 3,
                "B"  => 4,
                "KN" => 5,
                _    => throw new ArgumentException()
            };
            chessPiece.IsBlack = cols[2].ToUpper() == "B";

            return chessPiece;
        }

        /// <summary>
        /// Print the battle-field to the console.
        /// </summary>
        /// <param name="chessPieces"></param>
        public static void Print(ChessPiece[] chessPieces)
        {
            var field = CreateField(chessPieces);

            string line = "   +";
            Console.Write("   ");
            for (int col = 0; col < field.GetLength(1); col++)
            {
                line += "---+";
                Console.Write($"  {(char)('A' + col)} ");
            }

            Console.WriteLine();
            Console.WriteLine(line);

            for (int row = field.GetLength(0) - 1; row >= 0; row--)
            {
                Console.Write($"{row + 1,3}|");
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == null)
                    {
                        Console.Write("   |");
                    }
                    else
                    {
                        Console.Write($"{ToChessPiece(field[row, col].Type),2} |");
                    }
                }

                Console.WriteLine();
                Console.WriteLine(line);
            }
        }

        private static string ToChessPiece(int type)
        {
            return Math.Abs(type) switch
            {
                6 => "P",
                1 => "K",
                2 => "Q",
                3 => "R",
                4 => "B",
                5 => "KN",
                _ => "  "
            };
        }

        public static bool IsValid(ChessPiece[] chessPieces)
        {
            return CreateField(chessPieces) != null;
        }

        public static bool IsValidPieceAmount(ChessPiece[] chessPieces)
        {
            int[] ShouldBeAmounts = new int[] { 0, 1, 1, 2, 2, 2, 8 };
            int[] amountsB        = new int[ShouldBeAmounts.Length];
            int[] amountsW        = new int[ShouldBeAmounts.Length];

            foreach (var piece in chessPieces)
            {
                if (piece.IsBlack)
                {
                    amountsB[piece.Type]++;
                }
                else
                {
                    amountsW[piece.Type]++;
                }
            }

            return amountsB[1] == 1 && // at least one king
                   amountsW[1] == 1 && // amountsB[1] == 1 &&
                   Tools.IsMax(amountsW, ShouldBeAmounts) && Tools.IsMax(amountsB, ShouldBeAmounts);
        }

        /// <summary>
        /// Create a field from a chessPiece array.
        /// </summary>
        /// <param name="chessPieces">The list of pieces.</param>
        /// <returns>valid field or null (if invalid).</returns>
        public static ChessPiece[,] CreateField(ChessPiece[] chessPieces)
        {
            if (!IsValidPieceAmount(chessPieces))
            {
                return null;
            }

            var field = new ChessPiece[8, 8];

            foreach (var chessPiece in chessPieces)
            {
                if (!ArrangeChessPiece(field, chessPiece))
                {
                    return null;
                }
            }

            return field;
        }

        public static bool CanArrangeChessPiece(ChessPiece[,] field, ChessPiece chessPiece)
        {
            int row = chessPiece.Row;
            int col = chessPiece.Col;

            return field[row, col] == null;
        }

        /// <summary>
        /// Arrange (set) a chessPiece on the battle-field.
        /// </summary>
        /// <param name="field">The field where to set the chessPiece.</param>
        /// <param name="chessPiece"></param>
        /// <returns>true if the chessPiece can be arranged, otherwise false</returns>
        public static bool ArrangeChessPiece(ChessPiece[,] field, ChessPiece chessPiece)
        {
            if (!CanArrangeChessPiece(field, chessPiece))
            {
                return false;
            }

            int row = chessPiece.Row;
            int col = chessPiece.Col;

            field[row, col] = chessPiece;

            return true;
        }
    }
}