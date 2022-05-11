/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: UpdateProductCsv
*--------------------------------------------------------------
*/

namespace UpdateProductCsv
{
    using System.Globalization;

    public class Product
    {
        public static void FromCsv(string line, out string productCode, out string description, out string taxClass, out decimal retail)
        {
            var elements = line.Split(';');

            productCode = elements[0];
            description = elements[1];
            taxClass    = elements[2];
            retail      = decimal.Parse(elements[3], CultureInfo.InvariantCulture);
        }

        public static string ToCsvLine(string productCode, string description, string taxClass, decimal retail)
        {
            return $"{productCode};{description};{taxClass};{retail.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}