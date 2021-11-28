using System;

namespace LinearMotion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entfernung [Ganzzahl in km/h]: ");
            double distance = Convert.ToInt32(Console.ReadLine());
            Console.Write("Geschwindigkeit A [Ganzzahl in km/h]: ");
            int velocityA = Convert.ToInt32(Console.ReadLine());
            Console.Write("Geschwindigkeit B [Ganzzahl in km/h]: ");
            int velocityB = Convert.ToInt32(Console.ReadLine());

            
            double positionA = 0;
            double positionB = distance;
            
            double moveA = velocityA / 60.0;
            double moveB = velocityB / 60.0;
            double movePerMinute =  moveA + moveB;
            double timeRequired = distance / movePerMinute;
            int fullMinutes = (int)timeRequired;
            for (int i = 0; i <= fullMinutes; i++ )
            {
                Console.WriteLine("Minute: {0,2} Position A: {1,5:f2} Position B: {2,5:f2} Distanz: {3,5:f2}",
                   fullMinutes, positionA, positionB, distance);
                positionA += moveA;
                positionB -= moveB;
                distance -= movePerMinute;
            }

            double target = moveA * timeRequired;
            int fullHours = (int)(timeRequired / 60);
            double minutes = timeRequired - fullHours;
            fullMinutes = (int)(minutes);
            double seconds = (minutes - fullMinutes) * 60;

            Console.WriteLine();
            Console.WriteLine("Treffpunkt auf Position {0,5:f2} nach {1} Stunden, {2} Minuten und {3} Sekunden",
                target, fullHours, fullMinutes, seconds);
            Console.ReadKey();
        }
    }
}
