using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometrie
{
    class Program
    {
        private const int FIELD_SIZE = 20;
        private const string FRAME = "■";
        private const string CIRCLE = "●";
        static void Main(string[] args)
        {
            Console.WriteLine("Geometrie");
            Console.WriteLine("=========");

            Board.Init(FIELD_SIZE, FIELD_SIZE, "Geometrie");
            
            // TODO

            Console.WriteLine("Taste drücken zum Beenden ...");
            Console.ReadKey();
            
        }

    }
}
