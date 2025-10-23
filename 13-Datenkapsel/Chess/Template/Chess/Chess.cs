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
            // TODO Read ChessPieces from csv file
        }

        /// <summary>
        /// Print the field to the console.
        /// </summary>
        /// <param name="chessPieces"></param>
        public static void Print(ChessPiece[] chessPieces)
        {
            // TODO print field to console
        }

        /// <summary>
        /// Create a field from a chessPiece array.
        /// </summary>
        /// <param name="chessPieces">The list of pieces.</param>
        /// <returns>valid field or null (if invalid).</returns>
        public static ChessPiece?[,]? CreateField(ChessPiece[] chessPieces)
        {
            //TODO Implement CreateField
        }

        // TODO Implement bool IsValidPieceAmount(ChessPiece[] chessPieces)
        // TODO Implement bool CanPlaceChessPiece(ChessPiece?[,] field, ChessPiece chessPiece)
        // TODO Implement bool bool PlaceChessPiece(ChessPiece?[,] field, ChessPiece chessPiece)
        // TODO Implement bool IsValidPawnPosition(ChessPiece?[,] field, ChessPiece chessPiece)

    }
}