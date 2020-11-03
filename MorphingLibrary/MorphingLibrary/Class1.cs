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
        public double[] calcNumerator(int resX, int resY, int max, int[,] relDist, int[,] outputCharPoints)
        {
            double[] total = new double[2];
            double actualDenom = 0;
            double cumulatedDenom = 0;
            for (int i = 0; i < max; i++)
            {
                actualDenom =Math.Pow(outputCharPoints[i, 0] - resX, 2)
                    + Math.Pow(outputCharPoints[i, 1] - resY, 2);
                if (actualDenom != 0)
                {
                    cumulatedDenom += 1 / actualDenom;
                    total[0] += relDist[i, 0] / actualDenom;
                    total[1] += relDist[i, 1] / actualDenom;
                }
            }
            total[0] = total[0] / cumulatedDenom;
            total[1] = total[1] / cumulatedDenom;
            return total;
        }

    }
}


