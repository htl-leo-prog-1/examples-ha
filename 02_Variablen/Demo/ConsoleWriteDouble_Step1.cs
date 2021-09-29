/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xABIF
 *--------------------------------------------------------------
 *              Herbert Aitenbichler 
 *--------------------------------------------------------------
 * Description: Demo - Ausgabe einer Gleitkommazahl
 * Die Ausgabe erfolgt mit voller Genauigkeit (16 Stellen).
 * Platzhaltersyntax funktiniert auch ohne Console.Write
 *--------------------------------------------------------------
*/

using System;

double radius = Math.Sqrt(2);

string ausgabe = $"Der Umfang eines Kreises mit dem Radius {radius} ist { 2.0 * radius * Math.PI }";

Console.WriteLine(ausgabe);
