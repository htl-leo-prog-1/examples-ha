using System;
using System.IO;
using System.Text;

namespace ConsultingHours;

/// <summary>
/// The csv-file 'Sprechstunden.csv' is read into an array
/// of teachers and printed to console. The user can
/// search for teachers containing one or more letters in the
/// name, and all selected teachers are then printed to the
/// console.
/// </summary>
public class Program
{
    static int Main(string[] args)
    {
        string fileName;

        if (!CheckArguments(args, out fileName))
        {
            return 1;
        }

        Console.Title = "Sprechstundenliste der HTL-Leonding";
        Console.WriteLine("Sprechstundenliste der HTL-Leonding");
        Console.WriteLine("===================================");

        Teacher[] allTeachers = ReadTeachersFromFile(fileName);
        Console.WriteLine("{0} Sprechstundensätze eingelesen: ", allTeachers.Length);
        ShowTeachers(allTeachers);

        Console.WriteLine();
        Console.Write("Buchstaben [a-z] die enthalten sein müssen (leere Eingabe für Ende): ");
        string selectedLetters = Console.ReadLine()!;
        Console.WriteLine();
        while (selectedLetters.Length > 0)
        {
            Teacher[] selectedTeachers = SelectTeachers(allTeachers, selectedLetters);
            ShowTeachers(selectedTeachers);
            Console.WriteLine();
            Console.Write("Buchstaben [a-z] die enthalten sein müssen (leere Eingabe für Ende): ");
            selectedLetters = Console.ReadLine()!;
            Console.WriteLine();
        }

        Console.WriteLine();
        RoomStatistic(allTeachers);


        return 0;
    }

    /// <summary>
    /// Überprüft die Kommandozeilenargumente und gibt den Dateinamen zurück, falls die Argumente korrekt sind.
    /// </summary>
    /// <param name="args"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    static bool CheckArguments(string[] args, out string fileName)
    {
        fileName = "Sprechstunden.csv";

        if (args.Length > 1)
        {
            Console.WriteLine("usage: ConsultingHours CSV-Filename");
            return false;
        }


        if (args.Length > 0)
        {
            fileName = args[0];
        }

        if (!File.Exists(fileName))
        {
            Console.WriteLine($"{fileName} does not exist");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Sprechstundendaten aus der csv-Datei in ein Array of Projekt einlesen.
    /// </summary>
    /// <returns>Neu angelegtes Sprechstundenarray</returns>
    static Teacher[] ReadTeachersFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename, Encoding.Default);
        Teacher[] teachers = new Teacher[lines.Length - 1];
        for (int index = 1; index < lines.Length; index++)
        {
            teachers[index - 1] = new Teacher();
            string[] elemente = lines[index].Split(';');
            teachers[index - 1].SetName(elemente[0]);
            teachers[index - 1].SetDay(elemente[1]);
            teachers[index - 1].SetTime($"{elemente[2]}-{elemente[3]}");
            teachers[index - 1].SetRoom(elemente[4]);
        }

        return teachers;
    }

    /// <summary>
    /// Sprechstundenliste auf den Bildschirm ausgeben.
    /// </summary>
    private static void ShowTeachers(Teacher[] teachers)
    {
        Teacher teacher;
        if (teachers.Length > 0)
        {
            string format = "{0,-27} {1,-10} {2,-14} {3,-5}";
            Console.WriteLine(format, "Name", "Tag", "Zeit", "Raum");
            for (int i = 0; i < teachers.Length; i++)
            {
                teacher = teachers[i];
                Console.WriteLine(format, teacher.GetName(),
                    teacher.GetDay(), teacher.GetTime(), teacher.GetRoom());
            }
        }
        else
        {
            Console.WriteLine("Keine Daten verfügbar!");
        }
    }

    /// <summary>
    /// Die Lehrer werden ausgewählt und zurückgegeben.
    /// Groß/Kleinschreibung wird dabei nicht beachtet.
    /// </summary>
    /// <param name="teachers">alle ehrer</param>
    /// <param name="selectedLetters">Buchstaben, die enthalten sein müssen</param>
    /// <returns>gewählte Sprechstundensätze</returns>
    private static Teacher[] SelectTeachers(Teacher[] teachers, string selectedLetters)
    {
        Teacher teacher;
        int countSelectedTeachers = 0;
        for (int i = 0; i < teachers.Length; i++)
        {
            teacher = teachers[i];
            string lowerCaseName = teacher.GetName().ToLower();
            string lowerCaseSelection = selectedLetters.ToLower();
            if (IsSelected(lowerCaseName, lowerCaseSelection))
            {
                countSelectedTeachers++;
            }
        }

        Teacher[] selectedTeachers = new Teacher[countSelectedTeachers];
        countSelectedTeachers = 0;
        for (int i = 0; i < teachers.Length; i++)
        {
            teacher = teachers[i];
            string lowerCaseName = teacher.GetName().ToLower();
            string lowerCaseSelection = selectedLetters.ToLower();
            if (IsSelected(lowerCaseName, lowerCaseSelection))
            {
                selectedTeachers[countSelectedTeachers++] = teacher;
            }
        }

        return selectedTeachers;
    }

    /// <summary>
    /// Überprüft, ob der Lehrer die Selektionskriterien erfüllt.
    /// </summary>
    /// <param name="teacher">Zu prüfender Lehrer</param>
    /// <param name="selectedLetters">Buchstaben, die enthalten sein müssen</param>
    /// <returns></returns>
    public static bool IsSelected(string name, string selectedLetters)
    {
        bool found = false;
        string lowerCaseName = name.ToLower();
        string lowerCaseSelection = selectedLetters.ToLower();
        for (int indexSelection = 0; indexSelection < lowerCaseSelection.Length; indexSelection++)
        {
            found = false;
            for (int indexLetter = 0; indexLetter < lowerCaseName.Length && !found; indexLetter++)
            {
                found = (lowerCaseName[indexLetter] == lowerCaseSelection[indexSelection]);
            }

            if (!found) // ein Buchstabe wurde nicht gefunden
            {
                return false;
            }
        }

        return true; // alle Buchstaben wurden gefunden
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="teachers"></param>
    static void RoomStatistic(Teacher[] teachers)
    {
        RoomStatistic[] rooms = BuildRooms(teachers);
        OrderRooms(rooms);
        ShowRooms(rooms);
    }

    /// <summary>
    /// Erstellt ein Array je einem Eintrag je vorkommenden Raum und der Anzahl, wie oft dieser Raum
    /// vorkommt. 
    /// </summary>
    /// <param name="teachers"></param>
    /// <returns></returns>
    static RoomStatistic[] BuildRooms(Teacher[] teachers)
    {
        RoomStatistic[] rooms = new RoomStatistic[teachers.Length];
        int cntRooms = 0;
        bool found;
        for (int i = 0; i < teachers.Length; i++) //Alle Sprechstundeneinträge durchsuchen
        {
            int actPos = 0;
            found = false;
            while (rooms[actPos] != null && (actPos < cntRooms) && (!found))
            {
                if (rooms[actPos].GetRoom() == teachers[i].GetRoom())
                    found = true;
                else
                    actPos++;
            }

            if (!found)
            {
                rooms[cntRooms] = new RoomStatistic();
                rooms[cntRooms].SetRoom(teachers[i].GetRoom());
                rooms[cntRooms].SetCount(1);
                cntRooms++;
            }
            else
            {
                rooms[actPos].SetCount(rooms[actPos].GetCount() + 1);
            }
        }

        //Array der richtigen Größe anlegen
        RoomStatistic[] newRooms = new RoomStatistic[cntRooms];
        for (int i = 0; i < cntRooms; i++) //Umkopieren
        {
            newRooms[i] = rooms[i];
        }

        return newRooms;
    }

    /// <summary>
    /// Sortiert die Räume nach der Anzahl der Personen (absteigend mit Insertion-Sort)
    /// </summary>
    /// <param name="rooms"></param>
    static void OrderRooms(RoomStatistic[] rooms)
    {
        RoomStatistic temp;
        int actPos;
        for (int i = 1; i < rooms.Length; i++)
        {
            temp = rooms[i];
            actPos = i - 1;
            while (actPos >= 0 && rooms[actPos].GetCount() < temp.GetCount())
            {
                rooms[actPos + 1] = rooms[actPos];
                actPos--;
            }

            rooms[actPos + 1] = temp;
        }
    }

    /// <summary>
    /// Gibt die Raumstatistik aus
    /// </summary>
    /// <param name="rooms"></param>
    private static void ShowRooms(RoomStatistic[] rooms)
    {
        Console.WriteLine("Raumstatistik:");
        Console.WriteLine("--------------");
        Console.WriteLine("{0,-8} {1}", "Raum", "Lehrer");
        for (int i = 0; i < rooms.Length; i++)
        {
            Console.WriteLine("{0,-8} {1}", rooms[i].GetRoom(), rooms[i].GetCount());
        }
    }
}