/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xABIF
 *--------------------------------------------------------------
 *              Herbert Aitenbichler 
 *--------------------------------------------------------------
 * Description: Demo - Turmrechnen
 * Formatierung mit Angabe der Feldbreite
 *--------------------------------------------------------------
*/

using System;

int wert=47;

Console.WriteLine($"{wert,5} * 2 = { wert * 2,5}");
wert = wert * 2;

Console.WriteLine($"{wert,5} * 3 = { wert * 3,5}");
wert = wert * 3;

Console.WriteLine($"{wert,5} * 4 = { wert * 4,5}");
wert = wert * 4;

Console.WriteLine($"{wert,5} / 2 = { wert / 2,5}");
wert = wert / 2;

Console.WriteLine($"{wert,5} / 3 = { wert / 3,5}");
wert = wert / 3;

Console.WriteLine($"{wert,5} / 4 = { wert / 4,5}");
wert = wert / 4;
