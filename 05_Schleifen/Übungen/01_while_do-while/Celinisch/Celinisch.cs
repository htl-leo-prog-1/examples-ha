/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: celinischen Sümpfen
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Willkommen in den celinischen Sümpfen");
bool exit = false;

do
{
    Console.Write("Hat Ihr celinischer Freund einen Knelt? (j/n) --> ");
    bool knelt = Console.ReadLine() == "j";
    Console.Write("Löpst er womöglich? (j/n)                     --> ");
    bool loepst = Console.ReadLine() == "j";
    Console.Write("Zur Manuseligkeit: manuselt er? (j/n)         --> ");
    bool manuselt = Console.ReadLine() == "j";
    Console.Write("Und jetzt ein Letztes: nopelt er etwa? (j/n)  --> ");
    bool nopelt = Console.ReadLine() == "j";

    string diagnose;
    if (knelt && manuselt)
    {
        diagnose = "Asi";
    }
    else if (!knelt && nopelt)
    {
        diagnose = "Bela";
    }
    else if (knelt && !manuselt && nopelt)
    {
        diagnose = "Cedi";
    }
    else if (!knelt && loepst && !nopelt && manuselt)
    {
        diagnose = "Cedi";
    }
    else if (!knelt && loepst && !nopelt && !manuselt)
    {
        diagnose = "Drudi";
    }
    else if (!manuselt && !nopelt && knelt)
    {
        diagnose = "Drudi";
    }
    else if (!knelt && !loepst && !nopelt && manuselt)
    {
        diagnose = "Drudi";
    }
    else if (!knelt && !loepst && !nopelt && !manuselt)
    {
        diagnose = "Cedi";
    }
    else
    {
        diagnose = "Unbekannt";
    }

    // *** Ausgabe ***
    Console.WriteLine();
    switch (diagnose)
    {
        case "Asi":
            Console.WriteLine("Ein Asi. Gratuliere!");
            break;
        case "Bela":
            Console.WriteLine("Beachtlich: ein Bela!");
            break;
        case "Cedi":
            Console.WriteLine("Ein Cedi. Naja...");
            break;
        case "Drudi":
            Console.WriteLine("Um Himmes Willen, ein Drudi");
            break;
        default:
            Console.WriteLine("Ein Gespenst! Das darf nicht sein!");
            break;
    }

    Console.WriteLine("Drücken Sie eine Taste für eine neue Testung (X für Exit)");
    exit = Console.ReadLine() == "X";
} while (!exit);