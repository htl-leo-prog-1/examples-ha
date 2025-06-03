/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Book Library
 *--------------------------------------------------------------
 */

namespace BookLibrary;

using System;
using System.IO;
using System.Text;

public class Program
{
    const string FILENAME_BOOKS = "books.csv";
    const string FILENAME_BOOKS_INVALID_ISBN = "books_invalid.csv";
    const string FILENAME_BOOKS_DUPLICATE_ISBN = "books_duplicate.csv";
    const string FILENAME_BOOKS_VALID = "books_valid.csv";

    static void Main(string[] args)
    {
        // TODO: Implement main here
    }

    // TODO: Implement required book methods here, eg.g ReadFromCsv
    // TODO: Implement required book methods here, eg.g WriteCsv
    // TODO: Implement required book methods here, eg.g SortBooks
    // TODO: Implement required book methods here, eg.g PrintBooks

    /// <summary>
    /// Eine gültige ISBN-Nummer besteht aus den Ziffern 0, ... , 9,
    /// 'x' oder 'X' (nur an der letzten Stelle)
    /// Die Gesamtlänge der ISBN beträgt 10 Zeichen.
    /// Für die Ermittlung der Prüfsumme werden die Ziffern 
    /// von links nach rechts mit 1 - 10 multipliziert und die 
    /// Produkte aufsummiert. Ist das rechte Zeichen ein x oder X
    /// wird als Zahlenwert 10 verwendet.
    /// Die Prüfsumme muss modulo 11 0 ergeben.
    /// </summary>
    /// <returns>Prüfergebnis</returns>
    public static bool CheckIsbn(string isbn)
    {
        //TODO: Implement CheckIsbn here (needed in unittests)

        throw new NotImplementedException();
    }
}