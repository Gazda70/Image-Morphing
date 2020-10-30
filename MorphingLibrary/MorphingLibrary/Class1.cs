using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphingLibrary { 
    public class Morphing
    {

        public Morphing() { }

        public void determinePointsForObtainingColor(int resX, int resY, int max, int[][] outputCharPoints,
           int[][] RelDistFirst, int[][] RelDistSecond, int[] firstColorSource, int[] secondColorSource, double[] firstPoint, double[] secondPoint)
        {
            firstPoint = calcNumerator(resX, resY, max, RelDistFirst, outputCharPoints);
            secondPoint = calcNumerator(resX, resY, max, RelDistSecond,outputCharPoints);
            if (!(Double.IsNaN(firstPoint[0]) || Double.IsNaN(firstPoint[1])
            || Double.IsNaN(secondPoint[0]) || Double.IsNaN(secondPoint[1])))
            {
                firstColorSource[0] = System.Convert.ToInt32(firstPoint[0]) + resX;
                firstColorSource[1] = System.Convert.ToInt32(firstPoint[1]) + resY;
                secondColorSource[0] = System.Convert.ToInt32(secondPoint[0]) + resX;
                secondColorSource[1] = System.Convert.ToInt32(secondPoint[1]) + resY;
            }
        }

        private double[] calcNumerator(int resX, int resY, int max, int[][] relDist, int[][] outputCharPoints)
        {
            double[] total = new double[2];
            double actualDenom = 0;
            double cumulatedDenom = 0;
            for (int i = 0; i < max; i++)
            {
                actualDenom = Math.Pow(outputCharPoints[i][0] - resX, 2)
                    + Math.Pow(outputCharPoints[i][1] - resY, 2);
                if (actualDenom != 0)
                {
                    cumulatedDenom += 1 / actualDenom;
                    total[0] += relDist[i][0] / actualDenom;
                    total[1] += relDist[i][1] / actualDenom;
                }
             /*   else
                {
                    total[0] += relDist[i][0];
                    total[1] += relDist[i][1];
                }*/
            }
            total[0] = total[0] / cumulatedDenom;
            total[1] = total[1] / cumulatedDenom;
            return total;
        }

    }
}


