using System;

const int GUESS_NUMBER = 75;
const int MAX_GUESSES = 10;

Console.WriteLine("Zahlenraten");
Console.WriteLine("===========\n");

int countTries = 0;
int guess = -1;

Console.WriteLine("Versuche meine Zahl zu erraten (1-100)!");
while (countTries <= MAX_GUESSES && guess != GUESS_NUMBER && guess != 0)
{
    countTries++;
    Console.Write("{0}. Versuch: ", countTries);
    guess = Convert.ToInt32(Console.ReadLine());
    if (guess != 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        if (GUESS_NUMBER < guess)
        {
            Console.WriteLine("   Gesuchte Zahl ist kleiner! ");
        }

        if (GUESS_NUMBER > guess)
        {
            Console.WriteLine("   Gesuchte Zahl ist größer! ");
        }

        Console.ResetColor();
    }
}

Console.WriteLine();
if (guess != GUESS_NUMBER)
{
    Console.WriteLine("Versuch abgebrochen.");
}
else
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    if (countTries > 10)
    {
        Console.WriteLine("Endlich geschafft!");
    }
    else if (countTries > 5)
    {
        Console.WriteLine("Schon ganz gut!");
    }
    else
    {
        Console.WriteLine("Tolle Leistung!");
    }

    Console.ResetColor();
}
