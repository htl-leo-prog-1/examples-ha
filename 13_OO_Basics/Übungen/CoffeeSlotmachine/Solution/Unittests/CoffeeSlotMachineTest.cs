/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: CoffeeSlotMachine Unittests
 *--------------------------------------------------------------
 */

namespace UnitTest;

using FluentAssertions;

using Xunit;

using CoffeeSlotMachine;


public class CoffeeSlotMachineTest
{
    [Fact]
    public void T01_DefaultConstructor()
    {
        var coffeeSlotMachine = new CoffeeSlotMachine();
        coffeeSlotMachine.CoinsInDepot.Should().Be(18, "Je Wert sollen 3 Münzen im Depot sein");
        coffeeSlotMachine.ProductsAvailable.Should().Be(3, "Defaultkonstruktor soll drei Produkte anlegen");
    }


    [Fact]
    public void T02_OwnConstructor()
    {
        var coins             = new[] { 1, 2, 3, 4, 5, 6 };
        var productNames      = new[] { "Kaffee", "Tee", "Suppe", "Milch" };
        var coffeeSlotMachine = new CoffeeSlotMachine(coins, productNames);
        coffeeSlotMachine.CoinsInDepot.Should().Be(21, "1-6 Münzen sollen im Depot sein");
        coffeeSlotMachine.ProductsAvailable.Should().Be(4, "Vier Produkte anlegen");
    }


    [Fact]
    public void T03_OwnConstructorAllEmpty()
    {
        var coins             = new int[0];
        var productNames      = new string[0];
        var coffeeSlotMachine = new CoffeeSlotMachine(coins, productNames);

        coffeeSlotMachine.CoinsInDepot.Should().Be(0, "Leeres Depot");
        coffeeSlotMachine.ProductsAvailable.Should().Be(0, "Keine Produkte");
    }


    [Fact]
    public void T04_NormalOrder()
    {
        int[] returnCoins;
        int   donation;

        var returnCoinsExpected = new[] { 0, 0, 0, 1, 0, 0 }; // 1* 50 cent
        var coins               = new[] { 1, 2, 3, 4, 5, 6 };
        var productNames        = new[] { "Kaffee", "Tee", "Suppe", "Milch" };
        var coffeeSlotMachine   = new CoffeeSlotMachine(coins, productNames);

        coffeeSlotMachine.InsertCoin(100).Should().BeTrue("InsertCoin sollte funktionieren");
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation).Should().BeTrue("SelectProduct sollte funktionieren");

        returnCoins.Should().BeEquivalentTo(returnCoinsExpected, "Arrays mit Retourgeld sind nicht gleich");
        donation.Should().Be(0, "Es konnte das gesamte Restgeld zurückgegeben werden");
        coffeeSlotMachine.CoinsInDepot.Should().Be(21, "100 cent hinein und 50 cent hinaus");
    }


    [Fact]
    public void T05_ThreeOrders200Cent()
    {
        int[] returnCoins;
        int   donation;

        var returnCoinsExpected = new[] { 0, 0, 0, 1, 1, 0 }; // 1 * 100 und 1* 50 cent
        var coins               = new[] { 0, 0, 0, 3, 3, 3 };
        var productNames        = new[] { "Kaffee", "Tee", "Suppe", "Milch" };
        var coffeeSlotMachine   = new CoffeeSlotMachine(coins, productNames);

        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);

        donation.Should().Be(0, "Es konnte das gesamte Restgeld zurückgegeben werden");
        coffeeSlotMachine.CoinsInDepot.Should().Be(6, "6 * 200 cent");
    }


    [Fact]
    public void T06_FourOrders200CentWithDonation()
    {
        int[] returnCoins;
        int   donation;

        var returnCoinsExpected = new[] { 0, 0, 0, 0, 0, 0 }; // 1 * 100 und 1* 50 cent
        var coins               = new[] { 0, 0, 0, 3, 3, 3 };
        var productNames        = new[] { "Kaffee", "Tee", "Suppe", "Milch" };
        var coffeeSlotMachine   = new CoffeeSlotMachine(coins, productNames);

        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation).Should().BeTrue("SelectProduct sollte funktionieren");
        returnCoins.Should().BeEquivalentTo(returnCoinsExpected, "Es bleiben keine passenden Münzen mehr übrig");
        donation.Should().Be(150, "Kein Retourgeld mehr");
        coffeeSlotMachine.CoinsInDepot.Should().Be(7, "7 * 200 cent");
    }


    [Fact]
    public void T07_FourOrders200CentWithLessDonation()
    {
        int[] returnCoins;
        int   donation;

        var returnCoinsExpected = new[] { 2, 3, 4, 0, 0, 0 };
        var coins               = new[] { 2, 3, 4, 3, 3, 3 };
        var productNames        = new[] { "Kaffee", "Tee", "Suppe", "Milch" };
        var coffeeSlotMachine   = new CoffeeSlotMachine(coins, productNames);

        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation).Should().BeTrue("SelectProduct sollte funktionieren");
        returnCoins.Should().BeEquivalentTo(returnCoinsExpected, "Ganzes Kleingeld wurde zurückgegeben");
        donation.Should().Be(30, "30 cent fehlen beim retourgeld");
        coffeeSlotMachine.CoinsInDepot.Should().Be(7, "7 * 200 cent");
    }


    [Fact]
    public void T08_FourOrders200CentEmptyMachine()
    {
        int[] returnCoins;
        int   donation;

        var returnCoinsExpected = new[] { 2, 3, 4, 0, 0, 0 };
        var coins               = new[] { 2, 3, 4, 3, 3, 3 };
        var productNames        = new[] { "Kaffee", "Tee", "Suppe", "Milch" };
        var coffeeSlotMachine   = new CoffeeSlotMachine(coins, productNames);

        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);

        coffeeSlotMachine.EmptyDepot().Should().Be(1400, "7 * 200 Cent");
        coffeeSlotMachine.CoinsInDepot.Should().Be(0, "Depot wurde geleert");
        coffeeSlotMachine.EmptyDepot().Should().Be(0, "Depot wurde gerade geleert");
    }

    [Fact]
    public void T09_IllegalCoins()
    {
        var coins             = new[] { 1, 2, 3, 4, 5, 6 };
        var productNames      = new[] { "Kaffee", "Tee", "Suppe", "Milch" };
        var coffeeSlotMachine = new CoffeeSlotMachine(coins, productNames);

        coffeeSlotMachine.InsertCoin(7).Should().BeFalse("7 ist keine gültige Münze");
        coffeeSlotMachine.InsertCoin(2).Should().BeFalse("2 ist keine gültige Münze");
        coffeeSlotMachine.InsertCoin(20).Should().BeTrue("20 ist eine gültige Münze");
        coffeeSlotMachine.InsertCoin(20).Should().BeTrue("20 ist eine gültige Münze");
        coffeeSlotMachine.InsertCoin(10).Should().BeTrue("10 ist eine gültige Münze");
        coffeeSlotMachine.InsertCoin(10).Should().BeFalse("Es wurden bereits 50 Cent eingeworfen");
    }

    [Fact]
    public void T10_MoreCoins()
    {
        int[] returnCoins;
        int   donation;

        var coins             = new[] { 1, 2, 3, 4, 5, 6 };
        var productNames      = new[] { "Kaffee", "Tee", "Suppe", "Milch" };
        var coffeeSlotMachine = new CoffeeSlotMachine(coins, productNames);

        coffeeSlotMachine.InsertCoin(20).Should().BeTrue("20 ist eine gültige Münze");
        coffeeSlotMachine.InsertCoin(20).Should().BeTrue("20 ist eine gültige Münze");
        coffeeSlotMachine.InsertCoin(10).Should().BeTrue("10 ist eine gültige Münze");
        coffeeSlotMachine.CoinsInDepot.Should().Be(21, "Münzen wurden noch nicht übernommen");
        coffeeSlotMachine.SelectProduct("Tee", out returnCoins, out donation).Should().BeTrue("Auswahl Tee sollte funktionieren");
        coffeeSlotMachine.CoinsInDepot.Should().Be(24, "3 Münzen dazu eingenommen");
    }

    [Fact]
    public void T11_MoreCoinsAndCancel()
    {
        int[] returnCoins;

        var returnCoinsExpected = new[] { 0, 1, 2, 0, 0, 0 };
        var coins               = new[] { 1, 2, 3, 4, 5, 6 };
        var productNames        = new[] { "Kaffee", "Tee", "Suppe", "Milch" };
        var coffeeSlotMachine   = new CoffeeSlotMachine(coins, productNames);

        coffeeSlotMachine.InsertCoin(20).Should().BeTrue("20 ist eine gültige Münze");
        coffeeSlotMachine.InsertCoin(20).Should().BeTrue("20 ist eine gültige Münze");
        coffeeSlotMachine.InsertCoin(10).Should().BeTrue("10 ist eine gültige Münze");
        coffeeSlotMachine.CoinsInDepot.Should().Be(21, "Münzen wurden noch nicht übernommen");
        coffeeSlotMachine.Credit.Should().Be(50, "50 Cent engeworfen");
        returnCoins = coffeeSlotMachine.CancelOrder();
        returnCoins.Should().BeEquivalentTo(returnCoinsExpected, "Stornierte Münzen stimmen nicht");
        coffeeSlotMachine.CoinsInDepot.Should().Be(21, "Alter Zustand bleibt erhalten");
        coffeeSlotMachine.Credit.Should().Be(0,  "Bestellung wurde abgebrochen");
    }

    [Fact]
    public void T12_ProductsCounter()
    {
        int[] returnCoins;
        int   donation;
        int   counter;

        var coins             = new[] { 2, 3, 4, 3, 3, 3 };
        var productNames      = new[] { "Kaffee", "Tee", "Suppe", "Milch" };
        var coffeeSlotMachine = new CoffeeSlotMachine(coins, productNames);

        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(100);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(100);
        coffeeSlotMachine.SelectProduct("tee", out returnCoins, out donation).Should().BeFalse("tee gibt es nicht, nur Tee");
        coffeeSlotMachine.SelectProduct("Tee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(50);
        coffeeSlotMachine.SelectProduct("Suppe", out returnCoins, out donation);
        coffeeSlotMachine.GetCounterForProduct("Kaffee", out counter);
        counter.Should().Be(2, "Es wurde 2 * Kaffee bestellt");
        coffeeSlotMachine.GetCounterForProduct("irgendwas", out counter).Should().BeFalse("Produkt irgendwas ist nicht vorhanden");
        counter.Should().Be(0, "Im Fehlerfall 0 zurückgeben");
        coffeeSlotMachine.GetCounterForProduct("Suppe", out counter);
        counter.Should().Be(1, "Suppe gab es 1*");
        coffeeSlotMachine.GetCounterForProduct("Milch", out counter);
        counter.Should().Be(0, "Milch wurde nie bestellt");
    }

    [Fact]
    public void T13_CoinsCounter()
    {
        int[] returnCoins;
        int   donation;
        int   counter;

        var coins             = new[] { 3, 3, 3, 3, 3, 3 };
        var productNames      = new[] { "Kaffee", "Tee", "Suppe", "Milch" };
        var coffeeSlotMachine = new CoffeeSlotMachine(coins, productNames);

        coffeeSlotMachine.InsertCoin(200);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(5);
        coffeeSlotMachine.InsertCoin(5);
        coffeeSlotMachine.InsertCoin(20);
        coffeeSlotMachine.InsertCoin(50);
        coffeeSlotMachine.SelectProduct("Kaffee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(20);
        coffeeSlotMachine.InsertCoin(20);
        coffeeSlotMachine.InsertCoin(20);
        coffeeSlotMachine.SelectProduct("Tee", out returnCoins, out donation);
        coffeeSlotMachine.InsertCoin(50);
        coffeeSlotMachine.SelectProduct("Suppe", out returnCoins, out donation);
        coffeeSlotMachine.GetCounterForCoin(5, out counter);
        counter.Should().Be(5, "Am Papier durchspielen, möglichst große Münzen zurückgeben");
        coffeeSlotMachine.GetCounterForCoin(10, out counter);
        counter.Should().Be(1, "Am Papier durchspielen, möglichst große Münzen zurückgeben");
        coffeeSlotMachine.GetCounterForCoin(20, out counter);
        counter.Should().Be(6, "Am Papier durchspielen, möglichst große Münzen zurückgeben");
        coffeeSlotMachine.GetCounterForCoin(50, out counter);
        counter.Should().Be(4, "Am Papier durchspielen, möglichst große Münzen zurückgeben");
        coffeeSlotMachine.GetCounterForCoin(100, out counter);
        counter.Should().Be(2, "Am Papier durchspielen, möglichst große Münzen zurückgeben");
        coffeeSlotMachine.GetCounterForCoin(200, out counter);
        counter.Should().Be(4, "Am Papier durchspielen, möglichst große Münzen zurückgeben");
    }
}