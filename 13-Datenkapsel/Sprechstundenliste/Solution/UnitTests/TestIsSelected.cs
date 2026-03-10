using ConsultingHours;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests;

[TestClass]
public class TestIsSelected
{
    [TestMethod()]
    public void T01_IsSelectedSimple()
    {
        string name = "Hallo";
        string selection = "a";
        Assert.IsTrue(Program.IsSelected(name, selection));
    }

    [TestMethod()]
    public void T02_IsSelectedSimpleNotIn()
    {
        string name = "Hallo";
        string selection = "x";
        Assert.IsFalse(Program.IsSelected(name, selection));
    }

    [TestMethod()]
    public void T03_UpperCase()
    {
        string name = "HALLO";
        string selection = "a";
        Assert.IsTrue(Program.IsSelected(name, selection));
    }

    [TestMethod()]
    public void T04_EmptyName()
    {
        string name = "";
        string selection = "a";
        Assert.IsFalse(Program.IsSelected(name, selection));
    }

    [TestMethod()]
    public void T05_EmptySelection()
    {
        string name = "Hallo";
        string selection = "";
        Assert.IsTrue(Program.IsSelected(name, selection));
        name = "";
        Assert.IsTrue(Program.IsSelected(name, selection));
    }

    [TestMethod()]
    public void T06_AllLetters()
    {
        string name = "Hallo";
        string selection = "olah";
        Assert.IsTrue(Program.IsSelected(name, selection));
    }

    [TestMethod()]
    public void T07_SomeLettersTwice()
    {
        string name = "Hallo";
        string selection = "llaahh";
        Assert.IsTrue(Program.IsSelected(name, selection));
    }

}