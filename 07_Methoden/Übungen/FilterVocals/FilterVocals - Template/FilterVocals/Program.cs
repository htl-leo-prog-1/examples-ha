using System;

namespace FilterVocals
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Vokale aus Text extrahieren");
            Console.WriteLine("===========================");
            
            //TODO

            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }


        /// <summary>
        /// Aus einem Text sind alle Vokale a,e,i,o,u zu filtern.
        /// Kommt ein Vokal öfter vor, ist nur das erste Auftreten zu
        /// berücksichtigen!
        /// Die Vokale können sowohl groß als auch klein geschrieben
        /// werden.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Text, der die Vokale enthält</returns>
        public static string FilterVocals(string text)
        {
            throw new NotImplementedException();
        }
    }
}
