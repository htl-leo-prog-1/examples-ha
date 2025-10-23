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
        Book[] books = ReadCSVFile(FILENAME_BOOKS);
        SortBooks(books);
        Console.WriteLine("AUSGABE SORTIERTE BÜCHERLISTE");
        Console.WriteLine("=============================");
        PrintBooks(books);

        Book[] invalidBooks = GetInvalidBooks(books);
        Console.WriteLine("AUSGABE BÜCHER MIT UNGÜLTIGER ISBN");
        Console.WriteLine("==================================");
        PrintBooks(invalidBooks);
        WriteCSVFile(FILENAME_BOOKS_INVALID_ISBN, invalidBooks);
        Console.WriteLine("Diese Bücher wurden in die Datei " + FILENAME_BOOKS_INVALID_ISBN + " gespeichert.");

        //// Bücher mit ungültigen ISBNs entfernen...
        //Book[] validBooks = RemoveInvalidBooks(books, FILENAME_BOOKS_INVALID_ISBN);
        //Console.WriteLine(books.Length - validBooks.Length + " Bücher mit ungültiger ISBN gefunden.");
        //Console.WriteLine("Es verbleiben " + validBooks.Length + " Bücher.");

        //// Bücher mit duplizierten ISBNs entfernen ...
        //Book[] validBooksNoDuplicates = RemoveDuplicates(validBooks, FILENAME_BOOKS_DUPLICATE_ISBN);
        //Console.WriteLine(validBooks.Length - validBooksNoDuplicates.Length + " Duplikate wurden gelöscht.");
        //Console.WriteLine("Es verbleiben endgültig " + validBooksNoDuplicates.Length + " Bücher.");

        //// Übriggebliebene gültige Bücher auf Datei schreiben
        //WriteCSVFile(FILENAME_BOOKS_VALID, validBooksNoDuplicates);

        string left = "Aaron";
        string right = "Adalbert";
        int result = left.CompareTo(right);


        Console.WriteLine("Eine Taste drücken für Beenden.");
        Console.ReadKey();
    }

    private static Book[] GetInvalidBooks(Book[] books)
    {
        Book[] invalidBooks = new Book[books.Length];
        int invalidCounter = 0;
        for (int i = 0; i < books.Length; i++)
        {
            if (!CheckIsbn(books[i].GetISBN()))
            {
                invalidBooks[invalidCounter] = books[i];
                invalidCounter++;
            }
        }

        invalidBooks = CopyArray(invalidBooks, invalidCounter);
        return invalidBooks;
    }

    private static Book[] RemoveDuplicates(Book[] books, string duplicateFileName)
    {
        SortBooks(books);
        Book[] validBooks = new Book[books.Length];
        Book[] duplicateBooks = new Book[books.Length];
        int validCounter = 0;
        int duplicateCounter = 0;
        string previousISBN = "";
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].GetISBN() != previousISBN)
            {
                validBooks[validCounter] = books[i];
                validCounter++;
                previousISBN = books[i].GetISBN();
            }
            else
            {
                duplicateBooks[duplicateCounter] = books[i];
                duplicateCounter++;
            }
        }

        validBooks = CopyArray(validBooks, validCounter);
        duplicateBooks = CopyArray(duplicateBooks, duplicateCounter);
        WriteCSVFile(duplicateFileName, duplicateBooks);
        return validBooks;
    }

    private static Book[] RemoveInvalidBooks(Book[] books, string invalidFileName)
    {
        Book[] invalidBooks = new Book[books.Length];
        Book[] validBooks = new Book[books.Length];
        int invalidCounter = 0;
        int validCounter = 0;
        for (int i = 0; i < books.Length; i++)
        {
            if (!CheckIsbn(books[i].GetISBN()))
            {
                invalidBooks[invalidCounter] = books[i];
                invalidCounter++;
            }
            else
            {
                validBooks[validCounter] = books[i];
                validCounter++;
            }
        }

        invalidBooks = CopyArray(invalidBooks, invalidCounter);
        validBooks = CopyArray(validBooks, validCounter);
        WriteCSVFile(invalidFileName, invalidBooks);
        return validBooks;
    }

    private static Book[] CopyArray(Book[] books, int counter)
    {
        Book[] resized = new Book[counter];
        for (int i = 0; i < counter; i++)
        {
            resized[i] = books[i];
        }

        return resized;
    }

    private static void SortBooks(Book[] books)
    {
        for (int left = 0; left < books.Length - 1; left++)
        {
            for (int right = left + 1; right < books.Length; right++)
            {
                if (SwapRequired(books[left], books[right]))
                {
                    Book temp = books[right];
                    books[right] = books[left];
                    books[left] = temp;
                }
            }
        }
    }

    private static bool SwapRequired(Book bookLeft, Book bookRight)
    {
        //return (bookRight.GetISBN().CompareTo(bookLeft.GetISBN()) == -1);
        if (bookRight.GetPublisher().CompareTo(bookLeft.GetPublisher()) == 0)
        {
            return (bookRight.GetAuthor().CompareTo(bookLeft.GetAuthor()) == -1);
        }

        return (bookRight.GetPublisher().CompareTo(bookLeft.GetPublisher()) == -1);
    }

    private static void PrintBooks(Book[] books)
    {
        int counter = 0;
        Console.WriteLine("Insgesamt " + books.Length + " Bücher");
        WriteTitle();
        for (int i = 0; i < books.Length; i++)
        {
            Console.WriteLine("{0,-10} {1,-40} {2,-30} {3}",
                books[i].GetISBN(),
                books[i].GetPublisher(),
                books[i].GetAuthor(),
                books[i].GetTitle()
            );
            counter++;
            if (counter == 20)
            {
                Console.Write("Eine Taste drücken für weiter, \'x\' für Ende der Ausgabe: ");
                string input = Console.ReadLine()!;
                if (input.ToLower() == "x")
                {
                    break;
                }

                counter = 0;
                Console.Clear();
                WriteTitle();
            }
        }
    }

    private static void WriteTitle()
    {
        Console.WriteLine("{0,-10} {1,-40} {2,-30} {3}",
            "ISBN", "VERLAG", "AUTOR", "TITEL");
    }

    private static void WriteCSVFile(string fileName, Book[] books)
    {
        string[] lines = new string[books.Length + 1];
        lines[0] = "Autor;Titel;Verlag;Isbn";
        for (int i = 0; i < books.Length; i++)
        {
            lines[i + 1] = books[i].GetAuthor() + ";"
                                                + books[i].GetTitle() + ";"
                                                + books[i].GetPublisher() + ";"
                                                + books[i].GetISBN();
        }

        File.WriteAllLines(fileName, lines, Encoding.Default);
    }

    private static Book[] ReadCSVFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName, Encoding.Default);
        Book[] books = new Book[lines.Length - 1];
        for (int i = 0; i < lines.Length - 1; i++)
        {
            string[] columns = lines[i + 1].Split(';');
            books[i] = new Book();
            books[i].SetAuthor(columns[0]);
            books[i].SetTitle(columns[1]);
            books[i].SetPublisher(columns[2]);
            books[i].SetISBN(columns[3]);
        }

        return books;
    }

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
        if (isbn.Length != 10)
        {
            //Debug.WriteLine($"!!! isbn {isbn} has no length of 10!");
            return false;
        }

        int sum = 0;
        for (int i = 0; i < 10; i++)
        {
            var ch = isbn[i];
            int number;
            if (char.IsDigit(ch))
            {
                number = ch - '0';
            }
            else // keine Ziffer  => x oder X an letzter Stelle
            {
                if (i != 9)
                {
                    return false;
                }
                else
                {
                    if (ch == 'x' || ch == 'X')
                    {
                        number = 10;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            // zahl enthält gültigen Wert
            sum += number * (i + 1);
        }

        return (sum % 11) == 0;
    }
}