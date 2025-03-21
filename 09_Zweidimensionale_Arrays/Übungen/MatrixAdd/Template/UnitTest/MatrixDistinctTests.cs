/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: MatrixAdd UnitTests
 *--------------------------------------------------------------
 */

namespace UnitTest
{
    using System.Linq;

    using FluentAssertions;

    using Matrix;

    using Xunit;

    public class MatrixDistinctTests
    {
        [Fact]
        public void T01_Distinct()
        {
            int[,] matrix =
            {
                { 3, 6, 7 },
                { 5, 3, 5 },
                { 6, 2, 9 }
            };

            MatrixTools.Distinct(matrix).Order().Should().BeEquivalentTo([2, 3, 5, 6, 7, 9]);
        }

        [Fact]
        public void T02_Distinct()
        {
            int[,] matrix =
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 0 },
            };

            MatrixTools.Distinct(matrix).Order().Should().BeEquivalentTo([0]);
        }

        [Fact]
        public void T03_Distinct()
        {
            int[,] matrix =
            {
                { 0, 1, 2 },
                { 0, 1, 2 },
                { 0, 1, 2 },
            };

            MatrixTools.Distinct(matrix).Order().Should().BeEquivalentTo([0, 1, 2]);
        }
    }
}