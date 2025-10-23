/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: SelectPupil
*--------------------------------------------------------------
*/

using System;

namespace SelectPupils.Tools;

public static class Tools
{
    public static Pupil[] Copy(Pupil[] src, int count)
    {
        var dest = new Pupil[count];
        for (int i = 0; i < Math.Min(count,src.Length); i++)
        {
            dest[i] = src[i];
        }

        return dest;
    }
}