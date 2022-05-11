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
    using System;
    using System.Globalization;
    using System.IO;

    public class UpdateProductCsv
    {
        public static int Main(string[] args)
        {
            if (!CheckArguments(args))
            {
                return 1;
            }

            var fileName   = args[0];
            var percentage = 1 + (double.Parse(args[1], CultureInfo.InvariantCulture) / 100.0);

            var fullPathName = Path.GetFullPath(fileName);
            var pathName     = $"{Path.GetDirectoryName(fullPathName)}\\";
            var bakPathName  = $"{pathName}{Path.GetFileNameWithoutExtension(fullPathName)}.bak";
            var tmpPathName  = $"{pathName}{Path.GetFileNameWithoutExtension(fullPathName)}.$$$";

            var products = ReadCsvFile(fullPathName);

            UpdateRetails(products, percentage);

            WriteCsv(products, tmpPathName);

            if (File.Exists(bakPathName))
            {
                File.Delete(bakPathName);
            }

            File.Move(fullPathName, bakPathName);
            File.Move(tmpPathName,  fullPathName);

            return 0;
        }

        static bool CheckArguments(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("usage: UpdateProductCsv CSV-Filename percentage");
                return false;
            }

            var fileName = args[0];

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"{fileName} does not exist");
                return false;
            }

            if (Path.GetExtension(fileName).ToUpper() != ".CSV")
            {
                Console.WriteLine("File is not of type .csv");
                return false;
            }

            return true;
        }

        static string[] ReadCsvFile(string filename)
        {
            return File.ReadAllLines(filename);
        }

        static void WriteCsv(string[] products, string fileName)
        {
            File.WriteAllLines(fileName, products);
        }

        static void UpdateRetails(string[] products, double percentage)
        {
            for (int i = 1; i < products.Length; i++)
            {
                products[i] = UpdateRetail(products[i], percentage);
            }
        }

        static string UpdateRetail(string product, double percentage)
        {
            string  productCode;
            string  description;
            string  taxClass;
            decimal retail;

            Product.FromCsv(product, out productCode, out description, out taxClass, out retail);

            retail = (decimal)Math.Round(((double)retail) * percentage, 2);

            return Product.ToCsvLine(productCode, description, taxClass, retail);
        }
    }
}