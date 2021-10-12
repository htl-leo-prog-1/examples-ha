/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description:
* Cost calculation for mobile phones
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Cost calculation for mobile phones");
Console.WriteLine("==================================");

Console.Write("Please enter the monthly cost [0..999]:");
var input       = Console.ReadLine();
var costMonthly = Convert.ToDouble(input);

if (costMonthly > 0.0 && costMonthly < 1000.0)
{
    Console.Write("Please enter annual service fee [0..999]:");
    input = Console.ReadLine();
    var serviceFee = Convert.ToDouble(input);
    if (serviceFee >= 0.0 && serviceFee < 1000.0)
    {
        Console.Write("Please enter activation cost [0..999]:");
        input = Console.ReadLine();
        var activationCost = Convert.ToDouble(input);
        if (activationCost >= 0.0 && activationCost < 1000.0)
        {
            if (activationCost != 0.0)
            {
                var firstYearTotalCost   = costMonthly * 12.0 + serviceFee + activationCost;
                var firstYearMonthlyCost = firstYearTotalCost / 12.0;

                Console.WriteLine($"First year cost: {firstYearTotalCost:f2}Euro, monthly: {firstYearMonthlyCost:f2}Euro");
            }

            var nextYearTotalCost   = costMonthly * 12.0 + serviceFee;
            var nextYearMonthlyCost = nextYearTotalCost / 12.0;

            Console.WriteLine($"Annual cost: {nextYearTotalCost:f2}Euro, monthly: {nextYearMonthlyCost:f2}Euro");
        }
        else
        {
            Console.WriteLine($"Error activation cost: 0 <= {activationCost:f2} < 1000");
        }
    }
    else
    {
        Console.WriteLine($"Error service fee: 0 <= {serviceFee:f2} < 1000");
    }
}
else
{
    Console.WriteLine($"Error monthly cost: 0 < {costMonthly:f2} < 1000");
}