/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Palindrom
*--------------------------------------------------------------
*/

using System;

string[] examples =
{
    "", "a", "AA", "AAa", "A A", "deified", "potato",
    "civic", "car", "radar", "hannah", "Otto", "#Otto#"
};

Console.WriteLine("*** Palindrome Checker ***");
Console.WriteLine();
Console.WriteLine("Here are a couple of examples to get you started:");

foreach (var word in examples)
{
    PrintOutput(word, CheckPalindrome(word));
}

Console.WriteLine();
Console.WriteLine("Now try to find one yourself!");
Console.WriteLine();

string userWord = ReadText();
PrintOutput(userWord, CheckPalindrome(userWord));

void PrintOutput(string word, bool[] checkResult)
{
    string NotOrEmpty(bool flag) => flag ? string.Empty : "not ";

    string palindromeStr = $"is {NotOrEmpty(checkResult[0])}a palindrome,";
    string startEndStr = $"has {NotOrEmpty(checkResult[1])}the same start & end char";
    string evenCharCountStr = $"and has {NotOrEmpty(checkResult[2])}an even number of characters";
    Console.WriteLine($"The word \"{word}\": {palindromeStr} {startEndStr} {evenCharCountStr}");
}

string ReadText()
{
    const int MIN_LENGTH = 1;
    const int MAX_LENGTH = 20;

    bool isOk;
    string text;
    do
    {
        Console.Write($"Enter a palindrome (only characters, min. {MIN_LENGTH}, max. {MAX_LENGTH}): ");
        text = Console.ReadLine();

        isOk = text.Length >= MIN_LENGTH && text.Length <= MAX_LENGTH && !ContainsDigitOrWhitespace(text);

        if (!isOk)
        {
            Console.WriteLine("Invalid input, try again...");
        }
    } while (!isOk);

    return text;
}

bool ContainsDigitOrWhitespace(string text)
{
    foreach (char ch in text)
    {
        if (ch == ' ' || char.IsDigit(ch))
        {
            return true;
        }
    }

    return false;
}

bool IsSameChar(char ch1, char ch2)
{
    return char.ToUpper(ch1) == char.ToUpper(ch2);
}

bool[] CheckPalindrome(string text)
{
    int length = text.Length;

    bool isPalindrome = length > 2;

    bool isStartEndEqual = length > 0 ? IsSameChar(text[0], text[length - 1]) : false;
    bool isEvenCharCount = length % 2 == 0;

    for (int i = 0; i < length / 2 && isPalindrome; i++)
    {
        if (!IsSameChar(text[i], text[length - (1 + i)]))
        {
            isPalindrome = false;
        }
    }

    return new[] {isPalindrome, isStartEndEqual, isEvenCharCount};
}