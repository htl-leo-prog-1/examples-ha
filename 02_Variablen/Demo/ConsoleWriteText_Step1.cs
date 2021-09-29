/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1ABIF
 *--------------------------------------------------------------
 *              Herbert Aitenbichler 
 *--------------------------------------------------------------
 * Description: Demo - Formatierte Ausgabe
 * Positive/Negative Feldbreiten beeinflussen die Ausrichtung.
 *--------------------------------------------------------------
*/

using System;

string name = "Max Mustermann";

Console.WriteLine( "**************************");
Console.WriteLine($"* { name , -22 } *");
Console.WriteLine( "**************************");
