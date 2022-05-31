/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Demo for Stream
*--------------------------------------------------------------
*/

using System;
using System.IO;
using System.Text;

string path = @"c:\tmp\test.txt";

if (File.Exists(path))
{
    File.Delete(path);
}

using (var sw = new StreamWriter(path, false, Encoding.Default))
{
    sw.WriteLine("This");
    sw.WriteLine("is some text");
    sw.WriteLine("to test");
    sw.WriteLine("reading");
}

using (StreamReader sr = new StreamReader(path, Encoding.Default))
{
    var line = sr.ReadLine();
    while (line != null)
    {
        Console.WriteLine();
        line = sr.ReadLine();
    }
}