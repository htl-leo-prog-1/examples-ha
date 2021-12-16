/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description:
* Binäre Suche, der Computer erratet eine Nummer
*--------------------------------------------------------------
*/

using System;

const int MIN_VALUE = 1;
const int MAX_VALUE = 1000;

Console.WriteLine("I guess a number");
Console.WriteLine("===============================");
Console.WriteLine();

Console.WriteLine($"Please choose a number between {MIN_VALUE} and {MAX_VALUE}");

int guessCount = 0;

int maxGuess = MAX_VALUE;
int minGuess = MIN_VALUE;

bool isEndGame = false;

while (!isEndGame)
{
    var guess = (maxGuess + minGuess) / 2;
    Console.WriteLine($"My guess is: {guess}");

    var answer = "";

    do
    {
        Console.Write($"Is your number [g]reater, [l]ess or [e]qual (x for end the game): ");
        // Console.Write($"Is your number [g]reater, [l]ess or [e]qual: ");
        answer = Console.ReadLine();
    } while (answer != "g" && answer != "l" && answer != "e" && answer != "x");

    switch (answer)
    {
        case "g":
            if (maxGuess == guess)
            {
                Console.Write($"You are cheating!");
                isEndGame = true;
            }
            else
            {
                minGuess = guess + 1;
                guessCount++;
            }

            break;
        case "l":
            if (minGuess == guess)
            {
                Console.Write($"You are cheating!");
                isEndGame = true;
            }
            else
            {
                maxGuess = guess - 1;
                guessCount++;
            }

            break;
        case "e":
            guessCount++;
            Console.Write($"I have found the number within {guessCount} tries.");
            isEndGame = true;
            break;
        case "x":
            isEndGame = true;
            break;
    }
}