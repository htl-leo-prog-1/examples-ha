/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              <NAME> 
*--------------------------------------------------------------
* Description: Palindrom
*--------------------------------------------------------------
*/

using System;

string[] examples =
{
    "", "a", "AA", "AAa", "A A", "deified", "potato",
    "civic", "car", "radar", "hannah", "Otto", "#Otto#", "1Otto1"
};

Console.WriteLine("*** Palindrome Checker ***");
Console.WriteLine();
Console.WriteLine("Here are a couple of examples to get you started:");
Console.WriteLine();

// TODO iterate examples array and print results

Console.WriteLine();
Console.WriteLine("Now try to find one yourself!");
Console.WriteLine();

string userWord = ReadText();
PrintOutput(userWord, CheckPalindrome(userWord));

void PrintOutput(string word, bool[] checkResult)
{
    // TODO print checked word an the check results in the correct format
}

string ReadText()
{
    const int MIN_LENGTH = 1;
    const int MAX_LENGTH = 20;

    string text = "";

    // TODO read a valid word from the console, retry until the user gets it right

    return text;
}

bool ContainsDigitOrWhitespace(string text)
{
    // TODO check if the given text contains any digit or whitespace

    return false;
}

bool[] CheckPalindrome(string text)
{
    /* TODO check the given word for three criteria:
     * 1) is the word a palindrome - the length has to be at least 3 characters
     * 2) has the word the same character at the first and last position
     * 3) consists the word of an even number of characters
    */

    bool[] dummyToDelete = { false, false, false };
    return dummyToDelete;
}