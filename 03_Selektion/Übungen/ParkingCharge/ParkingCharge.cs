/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description:
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Calculate parking charge");
Console.WriteLine("========================");
Console.WriteLine();

const double MINCHARGE           = 2.0;
const double HOURSCHARGEFIRST    = 5.0;
const double CHARGEPERHOUREFIRST = 1;
const double CHARGEPERHOUREAFTER = 0.5;
const double MAXCHARGE           = 10.0;

Console.Write("Please enter hours: ");
var parkingHours = Convert.ToDouble(Console.ReadLine());

while (parkingHours > 0)
{
    var charge = 0.0;

    // parkingHours = Math.Ceiling(parkingHours);
    // round 1/2 hour
    parkingHours = Math.Ceiling(parkingHours * 2.0) / 2.0;

    if (parkingHours > 24)
    {
        var days = (int)parkingHours / 24;
        charge       =  days * MAXCHARGE;
        parkingHours -= days * 24;
    }

    var dayCharge = 0.0;

    if (parkingHours >= HOURSCHARGEFIRST)
    {
        dayCharge    = (parkingHours - HOURSCHARGEFIRST) * CHARGEPERHOUREAFTER;
        parkingHours = HOURSCHARGEFIRST;
    }

    dayCharge += parkingHours * CHARGEPERHOUREFIRST;

    if (dayCharge > MAXCHARGE)
    {
        dayCharge = MAXCHARGE;
    }

    if (dayCharge < MINCHARGE)
    {
        dayCharge = MINCHARGE;
    }

    charge += dayCharge;

    Console.WriteLine($"You have to pay {charge:F2} Euro");

    Console.Write("Please enter hours: (0 to exit): ");
    parkingHours = Convert.ToDouble(Console.ReadLine());
}