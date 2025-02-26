/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Demo Parameter/Variable
 *--------------------------------------------------------------
 */

using System;

namespace StackFrame
{
    class Program
    {
        public static void Main()
        {
            int varMain1 = 1;
            int varMain2 = 2;
            int varMain3;

            varMain1 = A(varMain1 + 1, varMain2 + 2);
            varMain2 = B(varMain1 + 3, varMain2 + 4);
            varMain3 = C(varMain1 + 5, varMain2 + 6);

            Console.WriteLine($"Main() => {varMain1},{varMain2},{varMain3}");
        }

        static int A(int pa1, int pa2)
        {
            int vara1 = pa1 * 2;
            int vara2 = pa2 * 4;

            pa1 = 2222;

            Console.WriteLine($"A({pa1},{pa2}) => {vara1},{vara2}");

            return vara1 + vara2;
        }

        static int B(int pb1, int pb2)
        {
            int varb1 = pb1 + 2;
            int varb2 = pb2 + 4;

            Console.WriteLine($"B({pb1},{pb2}) => {varb1},{varb2}");

            return varb1 + varb2;
        }

        static int C(int pc1, int pc2)
        {
            int varc1 = A(pc1 - 1, pc2 - 2);
            int varc2 = B(pc1 - 3, pc2 - 4);

            Console.WriteLine($"C({pc1},{pc2}) => {varc1},{varc2}");

            return varc1 + varc2;
        }
    }
}