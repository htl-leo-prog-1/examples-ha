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
        public static string[,] ReadFromCsv(string fileName)
        {
            var lines       = File.ReadAllLines(fileName);
            var chessPieces = new string[lines.Length - 1, 4]; // -1 because of header

            for (int i = 1; i < lines.Length; i++)
            {
                var cols    = lines[i].Split(';');
                int pieceId = i - 1;

                chessPieces[pieceId, 0] = (cols[0][1] - '1').ToString();
                chessPieces[pieceId, 1] = (cols[0][0] - 'A').ToString();

                chessPieces[pieceId, 2] = cols[1];
                chessPieces[pieceId, 3] = cols[2];
            }

            return chessPieces;
        }

        /// <summary>
        /// Check if the chess-board is valid.
        /// </summary>
        /// <param name="chessPieces"></param>
        public static bool IsValid(string[,] chessPieces)
        {
            return true;
        }


        /// <summary>
        /// Output the chess to the board.
        /// </summary>
        /// <param name="chessPieces"></param>
        public static void ToBoard(string[,] chessPieces)
        {
            for (int i = 0; i < chessPieces.GetLength(0); i++)
            {
                Board.SetText(int.Parse(chessPieces[i, 0]),
                    int.Parse(chessPieces[i, 1]),
                    ToBoardString(chessPieces[i, 2]),
                    ToBoardColor(chessPieces[i, 3]));
            }
        }

        private static string ToBoardColor(string chessPiecesColor)
        {
            return chessPiecesColor switch
            {
                "B" => "Black",
                "W" => "Red",
                _   => throw new ArgumentException()
            };
        }

        private static string ToBoardString(string chessPiecesType)
        {
            return chessPiecesType;
        }
        /*
                public static bool IsValid(string[,] chessPieces)
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
                public static ChessPiece[,] CreateField(ChessPiece[] chessPieces)
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
                public static bool CanPlaceChessPiece(ChessPiece[,] field, ChessPiece chessPiece)
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
                private static bool IsValidPawnPosition(ChessPiece[,] field, ChessPiece chessPiece)
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
                public static bool PlaceChessPiece(ChessPiece[,] field, ChessPiece chessPiece)
                {
                    if (!CanPlaceChessPiece(field, chessPiece))
                    {
                        return false;
                    }

                    field[chessPiece.Row, chessPiece.Col] = chessPiece;

                    return true;
                }
        */
    }
}