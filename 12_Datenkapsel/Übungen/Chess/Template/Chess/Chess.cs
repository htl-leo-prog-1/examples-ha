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
        }

        /// <summary>
        /// Print the battle-field to the console.
        /// </summary>
        /// <param name="chessPieces"></param>
        public static void Print(ChessPiece[] chessPieces)
        {

        }
        
        public static bool IsValid(ChessPiece[] chessPieces)
        {

        }

        public static bool IsValidPieceAmount(ChessPiece[] chessPieces)
        {
        }

        /// <summary>
        /// Create a field from a chessPiece array.
        /// </summary>
        /// <param name="chessPieces">The list of pieces.</param>
        /// <returns>valid field or null (if invalid).</returns>
        public static ChessPiece[,] CreateField(ChessPiece[] chessPieces)
        {
        }


        /// <summary>
        /// Arrange (set) a chessPiece on the battle-field.
        /// </summary>
        /// <param name="field">The field where to set the chessPiece.</param>
        /// <param name="chessPiece"></param>
        /// <returns>true if the chessPiece can be arranged, otherwise false</returns>
        public static bool ArrangeChessPiece(ChessPiece[,] field, ChessPiece chessPiece)
        {
        }
    }
}