/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: CreditcardChecker UnitTest
*--------------------------------------------------------------
*/

namespace UnitTest
{
    using FluentAssertions;
    using CreditcardChecker;
    using Xunit;

    public class ProgramTests
    {
        /// <summary>
        ///A test for IsCreditCardValid
        ///</summary>
        [Fact]
        public void T01_IsCreditCard_OK()
        {
            string creditCardNumber = "2718281828458567";
            Program.IsCreditCardValid(creditCardNumber).Should().BeTrue();
        }

        [Fact]
        public void T02_IsCreditCard_Checksum_NotOK()
        {
            string creditCardNumber = "2718281828458566";
            Program.IsCreditCardValid(creditCardNumber).Should().BeFalse();
        }

        [Fact]
        public void T03_IsCreditCard_Length_NotOK()
        {
            string creditCardNumber = "27182818284585666";
            Program.IsCreditCardValid(creditCardNumber).Should().BeFalse("Länge stimmt nicht");
        }

        [Fact]
        public void T04_IsCreditCard_Letter()
        {
            string creditCardNumber = "2718281828X58566";
            Program.IsCreditCardValid(creditCardNumber).Should().BeFalse("Enthält Buchstaben");
        }

        [Fact]
        public void T05_IsCreditCard_OK_Zero()
        {
            string creditCardNumber = "2418281828458560";
            Program.IsCreditCardValid(creditCardNumber).Should().BeTrue();
        }


        /// <summary>
        ///A test for calculateDigitSum
        ///</summary>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 1)]
        [InlineData(9, 9)]
        [InlineData(18, 9)]
        [InlineData(1234, 10)]
        [InlineData(98765, 35)]
        public void T11_CalculateDigitSum(int number, int expected)
        {
            Program.CalculateDigitSum(number).Should().Be(expected);
        }

        /// <summary>
        ///A test for calculateCheckDigit
        ///</summary>
        [Fact]
        public void T12_CalculateCheckDigit_Zero()
        {
            int oddSum = 0;
            int evenSum = 0;
            int expected = 0;
            Program.CalculateCheckDigit(oddSum, evenSum).Should().Be(expected);
        }

        /// <summary>
        ///A test for calculateCheckDigit
        ///</summary>
        [Fact]
        public void T13_CalculateCheckDigitTest_Normal()
        {
            int oddSum = 49;
            int evenSum = 34;
            int expected = 7;
            Program.CalculateCheckDigit(oddSum, evenSum).Should().Be(expected);
        }
    }
}