void Print(string message, int value)
{
  Console.Write($"{message}-{value}");
  value = 10;
  message = "Hallo Welt";
  Console.Write($"{message}-{value}");
} 

string message = "Hallo world";
int value = 11;

Print(message,value);
Console.Write($"{message}-{value}");
