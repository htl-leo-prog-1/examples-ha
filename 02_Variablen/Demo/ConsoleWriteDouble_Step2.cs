/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xABIF
 *--------------------------------------------------------------
 *              Herbert Aitenbichler 
 *--------------------------------------------------------------
 * Description: Demo - Ausgabe einer Gleitkommazahl
 * Gleitkommazahlen werden mit einer Genauigkeit 
 * von 4 Nachkommastellen ausgegeben.
 *--------------------------------------------------------------
*/

using System;

double radius=Math.Sqrt(2);

Console.WriteLine($"Der Umfang eines Kreises mit dem Radius {radius:f4} ist { 2.0 * radius * Math.PI:f4}");
