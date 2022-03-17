/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: CreditcardChecker UnitTest
*--------------------------------------------------------------
*/

namespace UnitTest;

using FluentAssertions;
using CreditcardChecker;
using Xunit;

public class CreditCardToolsTests
{
    [Theory]
    [InlineData("2418281828458560")]
    [InlineData("2718281828458567")]
    public void T01_ValidCreditCards(string creditCardNumber)
    {
        CreditCardTools.IsCreditCardValid(creditCardNumber).Should().BeTrue();
    }

    [Theory]
    [InlineData("27182818284585666", "Länge stimmt nicht")]
    [InlineData("2718281828X58566", "Enthält Buchstaben")]
    [InlineData("2718281828458566", "Checksum_NotOK")]
    public void T02_InvalidCreditCards(string creditCardNumber, string because)
    {
        CreditCardTools.IsCreditCardValid(creditCardNumber).Should().BeFalse(because);
    }

    /// <summary>
    ///A test for calculateDigitSum
    ///</summary>
    [Theory]
    [InlineData(-12, 3)]
    [InlineData(0, 0)]
    [InlineData(10, 1)]
    [InlineData(9, 9)]
    [InlineData(18, 9)]
    [InlineData(1234, 10)]
    [InlineData(98765, 35)]
    public void T03_CalculateDigitSum(int number, int expected)
    {
        CreditCardTools.CalculateDigitSum(number).Should().Be(expected);
    }

    /// <summary>
    ///A test for calculateCheckDigit
    ///</summary>
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(49, 34, 7)]
    public void T04_CalculateCheckDigit(int oddSum, int evenSum, int expected)
    {
        CreditCardTools.CalculateCheckDigit(oddSum, evenSum).Should().Be(expected);
    }
}