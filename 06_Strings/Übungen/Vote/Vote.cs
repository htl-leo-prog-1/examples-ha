/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Vote
 * Auswertung eies Wahlergebnisses
 *--------------------------------------------------------------
 */

using System;

const int Length100 = 50;

Console.WriteLine("Vote Result");
Console.WriteLine("**************************** Task 1");

Console.Write("Please enter votes (or blank): ");
string votes = Console.ReadLine();
string allVotes = "";

while (!string.IsNullOrEmpty(votes))
{
    allVotes += votes;
    Console.Write("Please enter votes (or blank): ");
    votes = Console.ReadLine();
}

Console.WriteLine("**************************** Task 2");

// find all patries => find distinct characters

string parties = "";

for (int i = 0; i < allVotes.Length; i++)
{
    char vote = allVotes[i];

    bool found = false;

    for (int n = 0; n < parties.Length && !found; n++)
    {
        found = parties[n] == vote;
    }

    if (!found)
    {
        parties += vote;
    }
}

Console.WriteLine($"The input contains {allVotes.Length} votes and {parties.Length} parties: {parties}");

Console.WriteLine("**************************** Task 3+4");

// output result

for (int i = 0; i < parties.Length; i++)
{
    char party = parties[i];
    int count = 0;

    for (int j = 0; j < allVotes.Length; j++)
    {
        if (allVotes[j] == party)
        {
            count++;
        }
    }

    double result = (double) count / allVotes.Length;
    string resultValue = "";

    int resultLength = (int) (result * Length100 + 0.5);

    for (int j = 0; j < resultLength; j++)
    {
        resultValue += '#';
    }

    Console.WriteLine($"'{party}': {count,3} ({result*100,4:F1}%) : {resultValue}");
}

Console.WriteLine("****************************");
