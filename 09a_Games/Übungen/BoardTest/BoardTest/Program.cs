/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Board-Test
*--------------------------------------------------------------
*/

using System;
using System.Threading;

Console.WriteLine("Board testen, läuft automatisch!");
Console.WriteLine("================================");

Console.WriteLine("Board mit Titel initialisieren");
Board.Init(10, 5, "Testboard"); // 10 Zeilen 5 Spalten
Thread.Sleep(5000);

Console.WriteLine("Text auf Board schreiben");
Board.SetText(3, 3, "X");
Thread.Sleep(5000);

string text = Board.GetText(3, 3);
Console.WriteLine("Text von Board lesen, gelesener Text: {0}", text);
Thread.Sleep(5000);

Console.WriteLine("Board löschen");
Board.Clear();
Thread.Sleep(5000);

Console.WriteLine("Text in Farbe rausschreiben");
Board.SetText(0, 2, "R", "Red");
Board.SetText(1, 2, "G", "Green");
Board.SetText(2, 2, "S", "Black");

System.Threading.Thread.Sleep(5000);
Console.WriteLine("Dimensionen des Boards mit GetLength() zurücklesen");
Console.WriteLine($"Zeilen: {Board.GetLength(0)}, Spalten: {Board.GetLength(1)}");
