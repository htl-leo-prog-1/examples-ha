/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *                Musterlösung - HA
 *--------------------------------------------------------------
 * Description:
 * Sort 3 values ("Dreieckstausch")
 *--------------------------------------------------------------
*/

using System;

int value1;
int value2;
int value3;

Console.WriteLine("Sort 3 values");
Console.WriteLine("-----------------------");

Console.Write("Please enter first value : ");
value1 = int.Parse(Console.ReadLine());

Console.Write("Please enter second value: ");
value2 = int.Parse(Console.ReadLine());

Console.Write("Please enter third value : ");
value3 = int.Parse(Console.ReadLine());

if (value1 > value2)
{
	int temp = value1;
	value1 = value2;
	value2 = temp;
}
	
if (value2 > value3)
{
	int temp = value2;
	value2 = value3;
	value3 = temp;
}
	
if (value1 > value2)
{
	int temp = value1;
	value1 = value2;
	value2 = temp;
}

Console.WriteLine($"Sorted values: {value1} <= {value2} <= {value3}");