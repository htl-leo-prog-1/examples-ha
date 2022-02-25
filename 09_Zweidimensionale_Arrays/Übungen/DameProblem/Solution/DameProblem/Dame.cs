/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Solve DameProblem
* see: https://de.wikipedia.org/wiki/Damenproblem
*--------------------------------------------------------------
*/

namespace DameProblem
{
    public class Dame
    {
        public static bool IsValid(bool[,] field)
        {
            if (field.GetLength(0) != 8 || field.GetLength(1) != 8)
            {
                return false;
            }
            int count = 0;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (field[x, y])
                    {
                        count++;
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            for (int dy = -1; dy <= 1; dy++)
                            {
                                if (!(dx == 0 && dy == 0))
                                {
                                    int x1 = x + dx;
                                    int y1 = y + dy;
                                    while (x1 >= 0 && x1 < 8 && y1 >= 0 && y1 < 8)
                                    {
                                        if (field[x1, y1])
                                        {
                                            return false;
                                        }
                                        x1 = x1 + dx;
                                        y1 = y1 + dy;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return count==8;
        }
    }
}
