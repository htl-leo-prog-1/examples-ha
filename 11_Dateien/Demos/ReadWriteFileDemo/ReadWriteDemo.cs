using System;
using System.IO;
using System.Text;

Console.WriteLine("Text aus einer Datei!");

/*
 * Arbeitsverzeichnis ist dort wo die .exe-Datei liegt, wird nur ein Dateiname (ohne Pfad) angegeben wird in diesem Working Directory gesucht
*/
// Ermittlung und Ausgabe des aktuellen Arbeitsverzeichnis
var workingDirectory = Directory.GetCurrentDirectory();
Console.WriteLine(workingDirectory);

string fileName = @"MyText.txt";

if (File.Exists(fileName))
{

/* 
 * Beispiel ReadAllText: Text aus einer Datei lesen
 */
    var content = File.ReadAllText(fileName, Encoding.Default);

    Console.WriteLine(content + "\n");
}

/* 
 * Beispiel ReadAllLines: Alle Zeilen einer Datei lesen
 */
var lines = File.ReadAllLines(@"c:\tmp\c#\..\MyText.txt", Encoding.Default);
for (int i = 0; i < lines.Length; i++)
{
    Console.WriteLine(lines[i]);
}

Console.WriteLine();

/* 
 * Beispiel WriteAllText: Überschreiben der Datei
 */
File.WriteAllText("MyText1.txt", "Das ist der neue Text!", Encoding.Default);

/* 
 * Beispiel WriteAllLines: Überschreiben der Datei mit einem string-Array 
 * WriteAllLines liest eine Zeile und schreibt die Zeile in ein Feld des Arrays
 * Wir werden die Zeilen der Datei reversieren
 */
var lines2Swap = File.ReadAllLines("MyText2.txt", Encoding.UTF8);

for (int i = 0; i < lines2Swap.Length / 2; i++)
{
    var swap = lines2Swap[i];
    lines2Swap[i] = lines2Swap[lines2Swap.Length - 1 - i];
    lines2Swap[lines2Swap.Length - 1 - i] = swap;
}

File.WriteAllLines("MyText2.txt", lines2Swap, Encoding.Default);

/*
 * Dateipfade 
 * - Maskierung - da der Backslash '\' für Escape-Sequenzen verwendet wird muss diesem ebenfalls ein '\' vorangestellt werden
 * - Unterdrückung der Escapesequeenzen durch voranstellen von '@'
 */
// Maskierung
const string FILENAME =
    "C:\\tmp\\CSharpFileExample.txt";
// wir lesen den Inhalt der Datei um zu sehen ob die Pfadangabe richtig ist
Console.WriteLine(File.ReadAllText(FILENAME));

// Unterdrückung Escapesequenz
const string FILENAME1 =
    @"C:\tmp\CSharpFileExample.txt";
// wir lesen den Inhalt der Datei um zu sehen ob die Pfadangabe richtig ist
Console.WriteLine(File.ReadAllText(FILENAME1));

// Erstellen eine Verzeichnisses
Directory.CreateDirectory("C:\\tmp\\beispielordner");

// Überprüfen ob Ornder schon existiert
if (Directory.Exists("C:\\tmp\\beispielordner"))
{
    Console.WriteLine("Der Ordner existiert bereits!!");
}


// Löschen eines Verzeichnisses
//Directory.Delete(@"C:\tmp\beispielordner");

// Lesen des Inhalts eines Verzeichnisses
var filesOfC = Directory.GetFiles("C:\\");
var directoriesOfC = Directory.GetDirectories("C:\\");
var contentOfC = new string[filesOfC.Length + directoriesOfC.Length];
directoriesOfC.CopyTo(contentOfC, 0);
filesOfC.CopyTo(contentOfC, directoriesOfC.Length);

// Wir schreiben den Inhalt des Ordners in ein Datei
File.WriteAllLines(@"c:\tmp\ContentOfC.txt", contentOfC);