using System;

Console.WriteLine("Video Rental System");
Console.WriteLine("*******************");

Console.Write("Please enter the price per day for the video: ");
int pricePerDay = Convert.ToInt32(Console.ReadLine());

Console.Write("Please enter the number of days the video was rented: ");
int numberOfDays = Convert.ToInt32(Console.ReadLine());

double totalAmount = 0;

if (numberOfDays < 1 || pricePerDay <= 0)
{
    Console.WriteLine("Invalid Input");
    return;
}

if (1 <= numberOfDays && numberOfDays <= 3)
    totalAmount = numberOfDays * pricePerDay;
else
{
    int amountForDays1To3 = 3 * pricePerDay;
    totalAmount = amountForDays1To3 + (numberOfDays - 3) * pricePerDay * 0.8;
}

totalAmount = Math.Min(totalAmount, 20);
Console.WriteLine("The total amount to be paid is " + totalAmount + " Euro");
Console.WriteLine();