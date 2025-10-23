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
                        if (!IsValidAllDirections(field, x, y))
                        {
                            return false;
                        }

                        count++;
                    }
                }
            }

            return count == 8;
        }

        private static bool IsValidAllDirections(bool[,] field, int x, int y)
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx != 0 || dy != 0) // both directions must not be 0
                    {
                        if (!IsValidDirection(field, x, y, dx, dy))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private static bool IsValidPos(int pos)
        {
            return pos >= 0 && pos < 8;
        }

        private static bool IsValidDirection(bool[,] field, int x, int y, int dx, int dy)
        {
            x += dx;
            y += dy;

            while (IsValidPos(x) && IsValidPos(y))
            {
                if (field[x, y])
                {
                    return false;
                }

                x += dx;
                y += dy;
            }

            return true;
        }
    }
}