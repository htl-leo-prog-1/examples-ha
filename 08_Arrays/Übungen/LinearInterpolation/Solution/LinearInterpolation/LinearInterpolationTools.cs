/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: linear Interpolation
*--------------------------------------------------------------
*/

namespace LinearInterpolation
{
    public static class LinearInterpolationTools
    {
        /// <summary>
        /// Get y value using the linear interpolation calculation.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="xValues">Array of x-Values</param>
        /// <param name="yValues">Array of y-Values</param>
        /// <returns>true if array contains distinct values.</returns>
        public static double Calculate(double x, double[] xValues, double[] yValues)
        {
            if (xValues.Length != yValues.Length || xValues.Length == 0)
            {
                return 0.0;
            }

            int lessIdx = -1;
            int greaterIdx = -1;

            double result;

            for (int i = 0; i < xValues.Length; i++)
            {
                if (x >= xValues[i])
                {
                    if (lessIdx == -1 || xValues[i] > xValues[lessIdx])
                    {
                        lessIdx = i;
                    }
                }
                if (x <= xValues[i])
                {
                    if (greaterIdx == -1 || xValues[i] < xValues[greaterIdx])
                    {
                        greaterIdx = i;
                    }
                }
            }

            if (greaterIdx == lessIdx)
            {
                result = yValues[greaterIdx];
            }
            else if (lessIdx == -1)
            {
                result = yValues[greaterIdx];
            }
            else if (greaterIdx == -1)
            {
                result = yValues[lessIdx];
            }
            else
            {
                result = ((x - xValues[lessIdx]) / (xValues[greaterIdx] - xValues[lessIdx]) *
                         (yValues[greaterIdx] - yValues[lessIdx])) + yValues[lessIdx];
            }

            return result;
        }
    }
}