/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Guess Number
 *--------------------------------------------------------------
 */


using System;

const int MAX_GUESSES = 10;
const int MAX_GUESS_VALUE = 100;

Console.WriteLine("Zahlenraten");
Console.WriteLine("===========");
Console.WriteLine();

int randomNumber = Random.Shared.Next(1, MAX_GUESS_VALUE + 1);

var random = new Random(); // Erzeugt einen Zufallszahlen-Generator
int guessNumber = random.Next(1, 101); // Zufallszahl von 1 bis 100 erzeugen


int countTries = 0;
int guess = -1;

Console.WriteLine("Versuche meine Zahl zu erraten (1-100)!");
while (countTries <= MAX_GUESSES && guess != randomNumber && guess != 0)
{
    countTries++;
    Console.Write($"{countTries}. Versuch: ");
    guess = int.Parse(Console.ReadLine());
    if (guess != 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        if (randomNumber < guess)
        {
            Console.WriteLine("   Gesuchte Zahl ist kleiner! ");
        }
        else if (randomNumber > guess)
        {
            Console.WriteLine("   Gesuchte Zahl ist größer! ");
        }

        Console.ResetColor();
    }
}

Console.WriteLine();
if (guess != randomNumber)
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