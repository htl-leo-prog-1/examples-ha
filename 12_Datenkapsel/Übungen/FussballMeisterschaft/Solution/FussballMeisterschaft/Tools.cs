/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Fussballmeisterschaft
*--------------------------------------------------------------
*/

namespace FussballMeisterschaft;

public static class Tools
{
    public static int IndexOf(Team[] teams, int count, string teamName)
    {
        for (int i = 0; i < count; i++)
        {
            if (teams[i].TeamName == teamName)
            {
                return i;
            }
        }

        return -1;
    }

    public static Game[] Copy(Game[] src, int count)
    {
        var dest = new Game[count];
        for (int i = 0; i < count; i++)
        {
            dest[i] = src[i];
        }

        return dest;
    }

    public static Team[] Copy(Team[] src, int count)
    {
        var dest = new Team[count];
        for (int i = 0; i < count; i++)
        {
            dest[i] = src[i];
        }

        return dest;
    }
}