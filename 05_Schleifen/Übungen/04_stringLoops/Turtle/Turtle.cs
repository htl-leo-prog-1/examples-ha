/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Turtle
* Eine Schildkröte läuf am Bildschirm
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Turtle");
Console.WriteLine("****************************");

string movementString;

do
{
    Console.WriteLine("D: Pen-down, U: Pen-up, 0:Up, 1:Up+Right, 2:Right, ... ");
    Console.WriteLine("Example: 'U1111D01234567' will draw a circle");

    string userInput;
    movementString = "";

    do
    {
        Console.Write("Please enter the movement string (empty to accept): ");
        userInput = Console.ReadLine();
        movementString += userInput;
    } while (userInput.Length > 0 && userInput[0] != '$');

    switch (movementString)
    {
        case "$1":
            movementString = "1111D222";
            break;
        case "$2":
            movementString = "U1111D01234567";
            break;
        case "$3":
            movementString = "U11111";
            movementString += "D0011223344556677";
            movementString += "U2222222222";
            movementString += "D0011223344556677";
            movementString += "U66000";
            movementString += "D44444";
            movementString += "U566";
            movementString += "D222222";
            break;
    }

    const int MAX_X = 80;
    const int MAX_Y = 25;

    var posX = 0;
    var posY = 0;
    var penDown = false;

    Console.SetWindowSize(MAX_X, MAX_Y);
    Console.Clear();

    for (int i = 0; i < movementString.Length; i++)
    {
        switch (char.ToUpper(movementString[i]))
        {
            case 'U':
                penDown = false;
                break;
            case 'D':
                penDown = true;
                break;
            case '0':
                posY++;
                break;
            case '1':
                posY++;
                posX++;
                break;
            case '2':
                posX++;
                break;
            case '3':
                posY--;
                posX++;
                break;
            case '4':
                posY--;
                break;
            case '5':
                posY--;
                posX--;
                break;
            case '6':
                posX--;
                break;
            case '7':
                posY++;
                posX--;
                break;
        }

        if (posX >= MAX_X)
        {
            posX = MAX_X - 1;
        }

        if (posY >= MAX_Y)
        {
            posY = MAX_Y - 1;
        }

        if (posX < 0)
        {
            posX = 0;
        }

        if (posY < 0)
        {
            posY = 0;
        }

        if (penDown)
        {
            Console.SetCursorPosition(posX, MAX_Y - 1 - posY);
            Console.Write('*');
        }
    }

    Console.SetCursorPosition(0, MAX_Y - 1);
    Console.WriteLine();
} while (movementString.Length > 0);