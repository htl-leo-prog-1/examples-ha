/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 *                 / _)     (  _ / _-- _/_ _ 
 *                /(_) .   __)( /)/ ()(/(-/  
 *--------------------------------------------------------------
 * Description: Besuch der Tante.  
 *--------------------------------------------------------------
*/

using System;

Console.WriteLine("Berechnung der Ankunftszeit bei der Tante");
Console.WriteLine("=========================================");
Console.WriteLine();

/**
 * Eingabe
 **/
Console.Write("Entfernung in km: ");
string distanceInput = Console.ReadLine();
double distance      = Convert.ToDouble(distanceInput);
Console.Write("Geschwindigkeit in km/h: ");
string velocityInput = Console.ReadLine();
double velocity      = Convert.ToDouble(velocityInput);

/**
 * Verarbeitung
 **/
double time             = distance / velocity;
int    fullHours        = (int)time;
double remainingMinutes = (time - fullHours) * 60;
int    fullMinutes      = (int)(remainingMinutes);
double remainingSeconds = (remainingMinutes - fullMinutes) * 60;
// Damit die restlichen Sekunden richtig gerundet werden, muss
// dann später der double-Wert inkl. Rest ausgegeben werden!
// Bei den Sekunden muss also der Rest erhalten bleiben!
fullHours += 10; // Abfahrt ist um 10:00

/**
 * Ausgabe
 **/
Console.WriteLine("Für die Strecke von {0:f} km benötigen Sie {1:f5} Stunden.", distance,  time);
Console.WriteLine("Sie kommen um {0}:{1:00}:{2:00} an.",                        fullHours, fullMinutes, remainingSeconds);