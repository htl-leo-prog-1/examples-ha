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
            const double MINIMUM_FR_FREE_SHIPPING = 29.0;

            Console.WriteLine("*****************");
            Console.WriteLine("* Shopping Cart *");
            Console.WriteLine("*****************");
            Console.WriteLine();

            int count = 0;
            double netPriceForAllProducts = 0;
            bool proceed = true;
            do{
                count++;
                Console.WriteLine("Eingabe von Produkt Nr. " + count);
                Console.Write("Netto-Stückpreis: ");
                double netPrice = Convert.ToDouble(Console.ReadLine());
                Console.Write("Stückzahl: ");
                int nrOfPieces = Convert.ToInt32(Console.ReadLine());
                Console.Write("Geschenkoption ((j)a / (n)ein): ");
                bool giftOption = (Console.ReadLine() == "j");
                netPrice *= nrOfPieces;
                Console.WriteLine("=> Nettopreis = {0:0.00} EUR", netPrice);
                if (giftOption){
                    netPrice += nrOfPieces * GIFT_PRICE;
                    Console.WriteLine("=> zuzügl. Geschenksoption = {0:0.00} EUR", (nrOfPieces * GIFT_PRICE));
                }
                netPriceForAllProducts += netPrice;
                Console.WriteLine();
                Console.Write("Ein weiteres Produkt eingeben ((j)a / (n)ein): ");
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

            Console.WriteLine("Nettopreis gesamt:    {0,20:0.00} EUR", netPriceForAllProducts);
            double taxValue = netPriceForAllProducts*vat/100.0;

            if (netPriceForAllProducts < MINIMUM_FR_FREE_SHIPPING)
            {
                netPriceForAllProducts = netPriceForAllProducts + SHIPPINGCOSTS;
                Console.WriteLine("Versandkosten:        {0,20:0.00} EUR", SHIPPINGCOSTS);
            }
            double totalPriceForAllProducts = netPriceForAllProducts + taxValue;
            Console.WriteLine("{0:0.00} % MWSt:         {1,20:0.00} EUR", vat, taxValue);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Gesamtpreis:          {0,20:0.00} EUR", totalPriceForAllProducts);
            Console.WriteLine("==============================================");

            Console.WriteLine("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }
    }
}
