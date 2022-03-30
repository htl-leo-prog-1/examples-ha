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





if (txt.Length < 14)
{
	isValid = true;
}
else
{
	isValid = false;
}

isValid = txt.Length < 14;







isValid = txt.Lenght > 14 ? true : false;





while (true)
{
	Console.WriteLine("Hallo Welt");
	
	isValid = ReadNumber();
	
	if (!isValid}
    {
		break;
	}
}

do
{
	isValid = ReadNumber();
}
while (!isValid);






bool isContinue = true;

while (isContinue)
{
	
	
	isContinue = ReadNumber();
}


for (int i=0; i<ar.Lenght; i++)
{
	ar[i] = CreateRandom();
	
	if (Contains(ar,i-1))
	{
		i--;
	}
}


for (int i=0; i<ar.Lenght; i++)
{
	{
		ar[i] = CreateRandom();
	}
 	while (!Contains(ar,i-1))

}



