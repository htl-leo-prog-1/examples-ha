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
            var cols       = line.Split(';');
            var chessPiece = new ChessPiece();

            chessPiece.Col = (int)(cols[0][0] - 'A');
            chessPiece.Row = (int)(cols[0][1] - '1');
            chessPiece.Type = cols[1] switch
            {
                "P"  => ChessPiece.Pawn,
                "K"  => ChessPiece.King,
                "Q"  => ChessPiece.Queen,
                "R"  => ChessPiece.Rook,
                "B"  => ChessPiece.Bishop,
                "KN" => ChessPiece.Knight,
                _    => throw new ArgumentException()
            };
            chessPiece.IsBlack = cols[2].ToUpper() == "B";

            return chessPiece;
        }

        /// <summary>
        /// Print the field to the console.
        /// </summary>
        /// <param name="chessPieces"></param>
        public static void Print(ChessPiece[] chessPieces)
        {
            var field = CreateField(chessPieces)!;

            string colHeader = "   ";
            string line      = "   +";
            for (int col = 0; col < field.GetLength(1); col++)
            {
                line      += "---+";
                colHeader += $"  {(char)('A' + col)} ";
            }

            Console.WriteLine(colHeader);
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
                        Console.Write($"{ToConsoleString(field[row, col]!),3}|");
                    }
                }

                Console.WriteLine(row + 1);
                Console.WriteLine(line);
            }

            Console.WriteLine(colHeader);
        }

        private static string ToChessPiece(ChessPiece chessPieces)
        {
            return chessPieces.Type switch
            {
                ChessPiece.Pawn   => "P",
                ChessPiece.King   => "K",
                ChessPiece.Queen  => "Q",
                ChessPiece.Rook   => "R",
                ChessPiece.Bishop => "B",
                ChessPiece.Knight => "KN",
                _                 => "  "
            };
        }

        private static string ToColor(ChessPiece chessPieces)
        {
            return chessPieces.IsBlack ? "b" : "w";
        }

        private static string ToConsoleString(ChessPiece chessPieces)
        {
            return $"{ToChessPiece(chessPieces)}{ToColor(chessPieces)}";
        }

        public static bool IsValid(ChessPiece[] chessPieces)
        {
            return CreateField(chessPieces) != null;
        }

        public static bool IsValidPieceAmount(ChessPiece[] chessPieces)
        {
            int[] amountsB = new int[ChessPiece.Pawn + 1];
            int[] amountsW = new int[ChessPiece.Pawn + 1];

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

            int morePiecesB =
                More(amountsB[ChessPiece.Queen],  1) +
                More(amountsB[ChessPiece.Rook],   2) +
                More(amountsB[ChessPiece.Bishop], 2) +
                More(amountsB[ChessPiece.Knight], 2);

            int morePiecesW =
                More(amountsW[ChessPiece.Queen],  1) +
                More(amountsW[ChessPiece.Rook],   2) +
                More(amountsW[ChessPiece.Bishop], 2) +
                More(amountsW[ChessPiece.Knight], 2);

            int possibleChangedPawnB = 8 - amountsB[ChessPiece.Pawn];
            int possibleChangedPawnW = 8 - amountsW[ChessPiece.Pawn];

            return amountsB[1] == 1 && // at least one king
                   amountsW[1] == 1 && // amountsB[1] == 1 &&
                   possibleChangedPawnW >= morePiecesW &&
                   possibleChangedPawnB >= morePiecesB;
        }

        private static int More(int count, int defaultCount)
        {
            return count <= defaultCount ? 0 : count - defaultCount;
        }

        /// <summary>
        /// Create a field from a chessPiece array.
        /// </summary>
        /// <param name="chessPieces">The list of pieces.</param>
        /// <returns>valid field or null (if invalid).</returns>
        public static ChessPiece?[,]? CreateField(ChessPiece[] chessPieces)
        {
            if (!IsValidPieceAmount(chessPieces))
            {
                return null;
            }

            var field = new ChessPiece[8, 8];

            foreach (var chessPiece in chessPieces)
            {
                if (!PlaceChessPiece(field, chessPiece))
                {
                    return null;
                }
            }

            return field;
        }

        /// <summary>
        /// Validate the field.
        /// Test, if a new chessPiece can be set to the filed.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="chessPiece"></param>
        /// <returns>true if the field is empty, false otherwise</returns>
        public static bool CanPlaceChessPiece(ChessPiece?[,] field, ChessPiece chessPiece)
        {
            int row = chessPiece.Row;
            int col = chessPiece.Col;

            return Tools.InRange(row, 7, 0) &&
                   Tools.InRange(col, 7, 0) &&
                   (chessPiece.Type != ChessPiece.Pawn || IsValidPawnPosition(field, chessPiece)) &&
                   field[row, col] == null;
        }

        /// <summary>
        /// Check if the pawn is on a valid row.
        /// Invalid rows are 0 or 7, depending on the color.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="chessPiece">chessPiece, must be a pawn.</param>
        /// <returns>true, if the pawn is on a valid row, otherwise false.</returns>
        private static bool IsValidPawnPosition(ChessPiece?[,] field, ChessPiece chessPiece)
        {
            int invalidRow = chessPiece.IsBlack ? 7 : 0;
            return chessPiece.Row != invalidRow;
        }

        /// <summary>
        /// Place (set) a chessPiece on the field.
        /// </summary>
        /// <param name="field">The field where to set the chessPiece.</param>
        /// <param name="chessPiece"></param>
        /// <returns>true if the chessPiece can be placed, otherwise false</returns>
        public static bool PlaceChessPiece(ChessPiece?[,] field, ChessPiece chessPiece)
        {
            if (!CanPlaceChessPiece(field, chessPiece))
            {
                return false;
            }

            field[chessPiece.Row, chessPiece.Col] = chessPiece;

            return true;
        }
    }
}