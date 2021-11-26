/***********************************************************************************************
 * Übungsnr:        07                                     
 * Programmname:    Dagobert                                  
 * Autor:           Michael Bucek  
 * Klasse:          1CHIF
 * Datum:           04.11.2013                               
 * ------------------------------------------------ 
 * Kurzbeschreibung:      
 * Der Bankier Dagobert weiß, dass sein Vermögen zwischen 1 bis 2 Millionen Dukaten liegt. 
 * Um sich die Zeit zu vertreiben, legt er seine Dukaten einmal in Quadrat- und einmal in Dreiecksform,
 * wobei er jeweils alle Münzen verwendet ohne eine übrig zu lassen. Wie viele Dukaten besitzt Dagobert?
 * ************************************************
*/
using System;


namespace Dagobert
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000;
            double dz;
            double root;
            int dagobertCoins = 0;

            do
            {
                //Dreieckszahl bestimmen
                dz = (n + 1) * n / 2.0;
                //Wenn Dreieckzahl größer als 1 Million prüfen ob Zahl im Quadrat gelegt werden kann
                if (dz >= 1000000)
                {
                    root = Math.Sqrt(dz);
                    if (root % 1 == 0) //Wurzel der Zahl ist eine Ganzzahl
                    {
                        dagobertCoins = Convert.ToInt32(dz); //Gesuchte Münzanzahl gefunden
                    }
                }
                //Basis der nächstes Dreieckszahl um 1 erhöhen
                //(Basis ist die Anzahl der Münzen in der untersten Reihe des Dreiecks!)
                n = n + 1;  
            } while ((dz <= 2000000) && (dagobertCoins==0));
            Console.WriteLine("Dagobert hat "+dagobertCoins+" Münzen!");
        }
    }
}
