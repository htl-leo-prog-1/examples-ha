/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: RationalNumber
* see:https://en.wikipedia.org/wiki/Rational_number
*--------------------------------------------------------------
*/

namespace RationalNumber
{
    using System;

    public class RationalNumber
    {
        public int Numerator   { get; private set; }
        public int Denominator { get; private set; }

        public double Value
        {
            get { return (double)Numerator / (double)Denominator; }
        }

        public RationalNumber(int numerator, int denominator)
        {
            Numerator   = numerator;
            Denominator = denominator;
        }

        public RationalNumber() : this(0, 1)
        {
        }

        private void NormalizeThis()
        {
            var ggt = Math.Abs(GGT(Numerator, Denominator));
            Numerator   = Numerator / ggt;
            Denominator = Denominator / ggt;

            if (Denominator < 0)
            {
                Numerator   = -Numerator;
                Denominator = -Denominator;
            } 
        }

        public RationalNumber Normalize()
        {
            var rat = new RationalNumber(Numerator, Denominator);
            rat.NormalizeThis();
            return rat;
        }

        private int GGT(int a, int b)
        {
            if (b != 0)
            {
                int c;
                do
                {
                    c = a % b;
                    a = b;
                    b = c;
                } while (c != 0);
            }

            return a;
        }

        public RationalNumber Add(RationalNumber val)
        {
            return new RationalNumber(
                Numerator * val.Numerator,
                Numerator * val.Denominator + Denominator * val.Numerator);
        }

        public RationalNumber Sub(RationalNumber val)
        {
            return new RationalNumber(
                Numerator * val.Numerator,
                Denominator * val.Numerator - Numerator * val.Denominator);
        }

        public RationalNumber Inverse()
        {
            return new RationalNumber(
                Numerator,
                -Denominator);
        }

        public RationalNumber Reciprocal()
        {
            return new RationalNumber(Denominator, Numerator);
        }

        public RationalNumber Mult(RationalNumber val)
        {
            return new RationalNumber(
                Numerator * val.Numerator,
                Denominator * val.Denominator);
        }

        public RationalNumber Div(RationalNumber b)
        {
            return Mult(b.Reciprocal());
        }
    }
}