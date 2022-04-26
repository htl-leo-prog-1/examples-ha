/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: GameOfLife
* see: https://de.wikipedia.org/wiki/Conways_Spiel_des_Lebens
*--------------------------------------------------------------
*/

namespace GameOfLife
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Game of Life");
            Console.WriteLine("============");


            // TODO: Implement "main" here 

            int size = 10;

            Board.Init(size, size, "Game of Life");

            Board.SetText(0, 0, "X");

            Console.ReadLine();

        }
        // TODO: if you need additional methods, implement them here
    }
}