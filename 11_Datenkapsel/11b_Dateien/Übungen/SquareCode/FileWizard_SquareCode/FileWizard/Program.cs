using System;
using System.IO;
using System.Text;

namespace FileWizard
{
    /// <summary>
    /// FileWizard erledigt einige einfache Konvertieraufgaben
    /// auf beliebigen Textdateien
    /// </summary>
    class Program
    {
        static ConsoleColor defaultColor = Console.ForegroundColor;
        const string LOGO_FILE = "logo.txt";

        static void Main(string[] args)
        {
            string logo = File.ReadAllText(LOGO_FILE, Encoding.Default);
            Console.WriteLine(logo);

            string fileName = GetFileName();
            bool finished = false;
            do
            {
                finished = PerformOperation(ref fileName);
            } while (!finished);

            Console.WriteLine("Vielen Dank, dass ich Dir helfen durfte!");
            System.Threading.Thread.Sleep(3000);
        }


        /// <summary>
        /// Erfragen eines Dateinamen vom Benutzer.
        /// Gibt dieser einen ungültigen Dateinamen ein
        /// (Datei existiert nicht), wird das Einlesen
        /// solange wiederholt, bis ein gültiger Dateiname
        /// eingelesen wurde.
        /// Verwende File.Exists
        /// </summary>
        /// <returns>Gültiger Dateiname (Datei existiert)</returns>
        private static string GetFileName()
        {
            string fileName;
            do
            {
                Console.Write("Welche Datei soll ich öffnen? ");
                fileName = Console.ReadLine();
                if (!File.Exists(fileName))
                {
                    Console.WriteLine("Diese Datei existiert nicht!");
                    fileName = null;
                }
            } while (fileName == null);
            CreateBackup(fileName);
            return fileName;
        }
        /// <summary>
        /// Präsentiert eine Auswahl an Datei-Funktionen
        /// und führt die vom Benutzer gewählte Funktion
        /// aus.
        /// Der Dateiname muss als ref-Parameter übergeben
        /// werden, da er sich durch das Einlesen einer
        /// neuen Datei auch ändern kann.
        /// Wenn "Ende" ausgewählt wurde, wird true 
        /// zurückgegeben
        /// </summary>
        /// <param name="fileName">Dateiname als Referenz</param>
        /// <returns>finished</returns>
        private static bool PerformOperation(ref string fileName)
        {
            Console.WriteLine("Was kann ich für Dich tun?");
            Log(fileName);
            Console.WriteLine("(1) Datei am Bildschirm ausgeben");
            Console.WriteLine("(2) Zeilennummern hinzufügen ");
            Console.WriteLine("(3) Zeilen reversieren ");
            Console.WriteLine("(4) Zeichenkette ersetzen");
            Console.WriteLine("(5) Neue Datei einlesen");
            Console.WriteLine("(6) Mit SquareCode verschlüsseln");
            Console.WriteLine("(7) Entschlüsseln von SquareCode");
            Console.WriteLine("(0) Ende");
            int operation = Convert.ToInt32(Console.ReadLine());
            switch (operation)
            {
                case 1: PrintFile(fileName); break;
                case 2: AddLineNumbers(fileName); break;
                case 3: ReverseLines(fileName); break;
                case 4: ReplaceCharacters(fileName); break;
                case 5: fileName = GetFileName(); break;
                case 6: EncryptFile(fileName); break;
                case 7: DecryptFile(fileName); break;
                default: break;
            }
            return operation == 0;
        }

        private static void EncryptFile(string fileName)
        {
            string content = File.ReadAllText(fileName, Encoding.Default);
            File.WriteAllText(fileName, SquareCode.Encrypt(content), Encoding.Default);
        }

        private static void DecryptFile(string fileName)
        {
            string content = File.ReadAllText(fileName, Encoding.Default);
            File.WriteAllText(fileName, SquareCode.Decrypt(content), Encoding.Default);
        }



        /// <summary>
        /// Erstellen einer Sicherungskopie einer Datei.
        /// Es wird an den Dateinamen '.bak' angehängt.
        /// Gibt es schon eine Sicherung mit diesem Namen,
        /// wird '.bak1' angehängt (bzw. '.bak2', '.bak3', usw.)
        /// Verwende File.Exists und File.Copy
        /// </summary>
        /// <param name="fileName">Zu sichernde Datei</param>
        private static void CreateBackup(string fileName)
        {
            string backupFileName = fileName + ".bak";
            int i = 1;
            string test = backupFileName;
            while (File.Exists(backupFileName))
            {
                backupFileName = fileName + ".bak" + i;
                i++;
            }
            File.Copy(fileName, backupFileName);
            Log("Datei " + backupFileName + " wurde erstellt.");
        }

        private static void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
        }

        /// <summary>
        /// Alle Zeilen der Datei werden eingelesen und
        /// in umgekehrter Reihenfolge wieder auf die
        /// Datei geschrieben.
        /// Verwende File.ReadAllLines und File.WriteAllLines
        /// </summary>
        /// <param name="fileName"></param>
        private static void ReverseLines(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName, Encoding.Default);
            for (int i = 0; i < lines.Length / 2; i++)
            {
                string swap = lines[i];
                lines[i] = lines[lines.Length - i - 1];
                lines[lines.Length - i - 1] = swap;
            }
            File.WriteAllLines(fileName, lines, Encoding.Default);
            Log("Zeilen in " + fileName + " wurden reversiert!");
        }


        /// <summary>
        /// Alle Zeilen der Datei werden eingelesen und
        /// mit einer Zeilennummer versehen wieder auf die
        /// gleiche Datei geschrieben.
        /// Verwende File.ReadAllLines und File.WriteAllLines
        /// </summary>
        /// <param name="fileName"></param>
        private static void AddLineNumbers(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName, Encoding.Default);
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = String.Format("{0, 2}: {1}", i + 1, lines[i]);
            }
            File.WriteAllLines(fileName, lines, Encoding.Default);
            Log("Zeilennummern in " + fileName + " hinzugefügt!");
        }

        /// <summary>
        /// Der Inhalt der Datei wird in eine string-Variable gelesen.
        /// Der Benutzer wird gefragt, welche Zeichenkette er durch
        /// welche andere Zeichenkette ersetzen will.
        /// Die Ersetzung wird in der string-Variable durchgeführt
        /// und das Ergebnis wieder auf die Datei geschrieben.
        /// Verwende File.ReadAllText und File.WriteAllText.
        /// </summary>
        /// <param name="fileName"></param>
        private static void ReplaceCharacters(string fileName)
        {
            Console.WriteLine("Welche(s) Zeichen soll(en) ersetzt werden?");
            string searchString = Console.ReadLine();
            Console.WriteLine("Wodurch? ");
            string replaceString = Console.ReadLine();

            string text = File.ReadAllText(fileName, Encoding.Default);
            text = text.Replace(searchString, replaceString);
            File.WriteAllText(fileName, text, Encoding.Default);
            Log("Alle \"" + searchString + "\" in " + fileName 
                + " wurden durch " + "\"" + replaceString + "\" ersetzt!");
        }
		
        /// <summary>
        /// Ausgabe der Textdatei auf die Konsole
        /// Verwende ReadAllText
        /// </summary>
        /// <param name="fileName"></param>
        private static void PrintFile(string fileName)
        {
            Console.WriteLine("------- Ausgabe Start -------");
            Log(File.ReadAllText(fileName, Encoding.Default));
            Console.WriteLine("------- Ausgabe Ende --------");
        }

    }
}
