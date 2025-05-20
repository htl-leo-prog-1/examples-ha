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

string fileName = @".\Data\Games.csv";

string[] content = File.ReadAllLines(fileName, Encoding.Default);

//foreach (string line in content)
for (int i=1;i<content.Length;i++)
{
        string[] col = content[i].Split(';');

    // do something with col
    col[2] = col[2].ToUpper();

    string convertedLine = string.Join(';', col);
    Console.WriteLine(convertedLine);
}
