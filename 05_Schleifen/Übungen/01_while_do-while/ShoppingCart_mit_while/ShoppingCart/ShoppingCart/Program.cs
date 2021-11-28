using System;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            const double GIFT_PRICE = 2.50;
            const int VAT_DE = 19;
            const int VAT_AT = 20;
            const double SHIPPINGCOSTS = 5.90;
            const double MINIMUM = 29.0;

            Console.WriteLine("*****************");
            Console.WriteLine("* Shopping Cart *");
            Console.WriteLine("*****************");
            Console.WriteLine();

            int count = 0;
            double priceForAllProducts = 0;
            bool proceed = true;
            do{
                count++;
                Console.WriteLine("Eingabe von Produkt Nr. " + count);
                Console.Write("Netto-Stückpreis: ");
                double netPrice = Convert.ToDouble(Console.ReadLine());
                Console.Write("Stückzahl: ");
                int nrOfPieces = Convert.ToInt32(Console.ReadLine());
                Console.Write("Geschenkoption ((j)a / (n)ein)? ");
                bool giftOption = (Console.ReadLine() == "j");
                netPrice *= nrOfPieces;
                Console.WriteLine("=> Nettopreis = {0:0.00} EUR", netPrice);
                if (giftOption){
                    netPrice += nrOfPieces * GIFT_PRICE;
                    Console.WriteLine("=> zuzügl. Geschenksoption = {0:0.00} EUR", (nrOfPieces * GIFT_PRICE));
                }
                priceForAllProducts += netPrice;
                Console.WriteLine();
                Console.WriteLine("Ein weiteres Produkt eingeben ((j)a / (n)ein)?");
                proceed = (Console.ReadLine() == "j");
            } while (proceed == true); 

            Console.Write("Lieferung nach de oder at? ");
            string destination = Console.ReadLine();
        
            double vat = 0.0;
            switch (destination)
            {
                case "de":
                    vat = VAT_DE;
                    break;
                case "at":
                    vat = VAT_AT;
                    break;
                default:
                    Console.WriteLine("Achtung - Mehrwertsteuersatz konnte nicht ermittelt werden. Falsche Eingabe: " + destination);
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine("Ihre Einkaufsrechnung ");
            Console.WriteLine("==============================================");
            Console.WriteLine();

            Console.WriteLine("Nettopreis gesamt:    {0,20:0.00} EUR", priceForAllProducts);
            priceForAllProducts = priceForAllProducts * (100 + vat) / 100;

            if (priceForAllProducts < MINIMUM)
            {
                priceForAllProducts = priceForAllProducts + SHIPPINGCOSTS;
                Console.WriteLine("Versandkosten:        {0,20:0.00} EUR", SHIPPINGCOSTS);
            }
            Console.WriteLine("Gesamtpreis:          {0,20:0.00} EUR", priceForAllProducts);
            Console.WriteLine("==============================================");

            Console.WriteLine("Darin enthalten sind {0:0.00} % MWSt: {1,7:0.00} EUR", vat, (priceForAllProducts / (100 + vat) * (vat)));

            Console.ReadKey();
        }
    }
}
