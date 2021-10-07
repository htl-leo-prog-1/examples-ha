/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xABIF
 *--------------------------------------------------------------
 *              Herbert Aitenbichler 
 *--------------------------------------------------------------
 * Description:
 * Tells you, when you are grown up
 *--------------------------------------------------------------
*/

using System;

const int GROWN_UP_AGE = 18;

Console.Write("How old are you? ");
var userInput = Console.ReadLine();
var age       = Convert.ToInt32(userInput);

var diff = GROWN_UP_AGE - age;

Console.WriteLine($"In approx. {diff} years you will be grown-up");
