using System;

Console.WriteLine("Percent to Grade!");

Console.Write("Bitte geben Sie die Prozente ein, die Sie erreicht haben: ");
double percent = Convert.ToDouble(Console.ReadLine());

string grade;
bool   inputOk = true;

if (0 <= percent && percent < 50)
    grade = "Nicht Genügend";
else if (50 <= percent && percent < 63)
    grade = "Genügend";
else if (63 <= percent && percent < 75)
    grade = "Befriedigend";
else if (75 <= percent && percent < 88)
    grade = "Gut";
else if (percent >= 88)
    grade = "Sehr Gut";
else
{
    inputOk = false;
    grade   = "Die Eingabe war ungültig";
}

string message;
if (inputOk)
    message = "Sie haben die Note " + grade + " erreicht.";
else
    message = grade;

Console.WriteLine(message);
