/***********************************************************************************************
 * Übungsnr:        07                                     
 * Programmname:    PI                                  
 * Autor:           Michael Bucek  
 * Klasse:          1CHIF
 * Datum:           04.11.2013                               
 * ------------------------------------------------ 
 * Kurzbeschreibung:      
 * Bestimme den Wert von PI näherungsweise!
 * ************************************************
*/

using System;

namespace PI
{
    class Program
    {
        static void Main(string[] args)
        {
            double res = 0;
            for (int i = 0; i < 10000; i++)
            {
                res = res + Math.Pow(-1, i) / (2 * i + 1);
            }
            res = res * 4;
            Console.WriteLine("PI="+res);
            Console.ReadLine();
        }
    }
}
