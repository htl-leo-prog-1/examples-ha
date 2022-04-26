using System;
using System.IO;

namespace CalendarManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            CalendarDate[] dates = SortCalendar(ReadFromCSV("CalendarDates"));
            PrintCalendar(dates);
            Console.ReadKey();
        }
        private static CalendarDate[] ReadFromCSV(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName + ".csv");
            CalendarDate[] dates = new CalendarDate[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] splittedString = lines[i].Split(';');
                string[] splittedDate = splittedString[0].Split('.');
                dates[i] = new CalendarDate();
                dates[i].SetDay(Convert.ToInt32(splittedDate[0])); 
                dates[i].SetMonth(Convert.ToInt32(splittedDate[1]));
                dates[i].SetYear(Convert.ToInt32(splittedDate[2]));
                dates[i].SetDescription(splittedString[1]);
            }
            return dates;
        }
        private static void PrintCalendar(CalendarDate[] dates)
        {
            for(int i = 0; i < dates.Length; i++)
            {
                if (dates[i].GetDay() < 10)
                {
                    Console.Write(" ");
                }
                Console.Write(dates[i].GetDay() + ".");
                if (dates[i].GetMonth() < 10)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(dates[i].GetMonth() + "." + dates[i].GetYear() + ": " + dates[i].GetDescription());
            }
        }
        private static CalendarDate[] SortCalendar(CalendarDate[] dates)
        {
            CalendarDate[] sortedDates = dates;
            for (int i = 0; i < dates.Length; i++)
            {
                int minimum = GetIndexOfMinimum(sortedDates, i);
                Swap(sortedDates, minimum, i);
            }
            return sortedDates;
        }
        private static int CompareTo(CalendarDate date1, CalendarDate date2)
        {
            if (date1.GetYear() < date2.GetYear())
            {
                return -1;
            }
            if (date1.GetYear() > date2.GetYear())
            {
                return 1;
            }
            if (date1.GetMonth() < date2.GetMonth())
            {
                return -1;
            }
            if (date1.GetMonth() > date2.GetMonth())
            {
                return 1;
            }
            if (date1.GetDay() < date2.GetDay())
            {
                return -1;
            }
            if (date1.GetDay() > date2.GetDay())
            {
                return 1;
            }
            return 0;
        }

        private static int GetIndexOfMinimum(CalendarDate[] dates, int startIndex)
        {
            int index = startIndex;
            for (int i = startIndex; i < dates.Length; i++)
            {
                if(CompareTo(dates[index], dates[i]) == 1)
                {
                    index = i;
                }
            }
            return index;
        }
        private static void Swap(CalendarDate[] dates, int i, int j)
        {
            CalendarDate temp = dates[i];
            dates[i] = dates[j];
            dates[j] = temp;
        }

    }
}
