/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: ConsoleCoffeeSlotMachine
*--------------------------------------------------------------
*/

namespace ConsoleCoffeeSlotMachine
{
    using System;

    class Program
    {
        private static int[] _coinValues = {5, 10, 20, 50, 100, 200}; // Wert der jeweiligen Münze
        private static int[] _coinsAmount = {3, 3, 3, 3, 3, 3}; // Initialisierung für Münzen von 5 - 200 Cent

        static void Main(string[] args)
        {
            Console.WriteLine("Kaffeeautomat mit Geldrückgabe");

            string userSelection = ShowMenu();

            while (userSelection != "X")
            {
                switch (userSelection)
                {
                    case "1":
                        BuyCoffee(60);
                        break;
                    case "2":
                        BuyCoffee(50);
                        break;
                    case "3":
                        ShowContent();
                        break;
                }

                userSelection = ShowMenu();
            }
        }

        static string ShowMenu()
        {
            string input;
            do
            {
                Console.WriteLine("**********************");
                Console.WriteLine("1 Kaffee kaufen (60Cent)");
                Console.WriteLine("2 Kakao kaufen  (50Cent)");
                Console.WriteLine("3 Münzanzahl ausgeben");
                Console.WriteLine("X Beenden");
                Console.Write("=>");
                input = Console.ReadLine().ToUpper();
            } while (input != "1" && input != "2" && input != "3" && input != "X");

            return input;
        }

        static void BuyCoffee(int coffeePrice)
        {
            Console.WriteLine("**********************");
            Console.WriteLine($"Preis {coffeePrice} Cent; möglicher Einwurf von {string.Join(',', _coinValues)} Cent");

            var sum = 0;
            do
            {
                int coinIndex = InsertValidCoin($"Bisher eingeworfen {sum}, Einwurf in Cent: ");

                _coinsAmount[coinIndex]++;
                sum += _coinValues[coinIndex];
            } while (sum < coffeePrice);

            var returnCents = sum - coffeePrice;
            Console.WriteLine($"Kaffeeausgabe, Einwurf: {sum} ==> Retourgeld: {returnCents} Cent");

            for (int coinIndex = _coinsAmount.Length - 1; returnCents > 0 && coinIndex >= 0; coinIndex--)
            {
                var needCoinsOfAmount = returnCents / _coinValues[coinIndex];
                var countOfAmount = Math.Min(needCoinsOfAmount, _coinsAmount[coinIndex]);

                if (countOfAmount > 0)
                {
                    _coinsAmount[coinIndex] -= countOfAmount;
                    returnCents -= _coinValues[coinIndex] * countOfAmount;

                    Console.WriteLine($"{countOfAmount} mal {_coinValues[coinIndex]} Cent");
                }
            }

            if (returnCents > 0)
            {
                Console.WriteLine($"Retourgeld von {returnCents} Cent ist im Automaten nicht mehr verfügbar, sorry!");
            }
        }

        static void ShowContent()
        {
            Console.WriteLine("**********************");
            Console.WriteLine("Folgende Münzen sind im Automaten");
            for (int i = 0; i < _coinsAmount.Length; i++)
            {
                Console.WriteLine($"{_coinValues[i]} Cent: {_coinsAmount[i]}");
            }
        }

        static int InsertValidCoin(string message)
        {
            int joinValue;
            bool isValid;
            do
            {
                Console.Write(message);
                isValid = int.TryParse(Console.ReadLine(), out joinValue) && Contains(_coinValues, joinValue);
                if (!isValid)
                {
                    Console.WriteLine("Bitte geben sie gültige Münzen ein!");
                }
            } while (!isValid);

            return IndexOf(_coinValues, joinValue);
        }

        static bool Contains(int[] array, int value)
        {
            return IndexOf(array, value) >= 0;
        }

        static int IndexOf(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}