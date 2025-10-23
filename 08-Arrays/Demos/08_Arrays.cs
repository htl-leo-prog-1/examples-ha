int[] numbers = new int[] { 2, 4, 3, 5, 5, 6, 4 };
int[] numbers = { 2, 4, 3, 5, 5, 6, 4 };
var numbers = new int[] { 2, 4, 3, 5, 5, 6, 4 };

int sum = 0;
for(int i =0; i< numbers.Length;i++)
{
    sum += numbers[i];
}
int sum = 0;
foreach (int number in numbers)
{
    sum += number;
}
Console.WriteLine($"Summe aller zahlen {sum}");

int[] numberOrig = new int[] { 2, 4, 3, 5, 5, 6, 4 };
int[] numberCopy = numberOrig;

numberCopy[0] = 20;

Console.WriteLine(numberOrig[0]);

int[] numbers = new int[10];

for (int i = 0; i < number.Length; i++)
{
	numbers[i] = int.Parse(Console.ReadLine());
}


int[] CreateArray(int count)
{
	var numbers = new int[count];
	
	for (int i=0;i<number.Length;i++)
	{
		numbers[i] = 2 * (i + 1);
	}
	
	return numbers;
}

void ModifyArray(int[] numbers, int addValue)
{
	for (int i = 0; i < number.Length; i++)
	{
		numbers[i] += addValue;
	}
}