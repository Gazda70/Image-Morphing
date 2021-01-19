using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphingLibrary { 

    /*Klasa zawierająca metodę biblioteczną*/
    public class Morphing
    {

        public Morphing() { }

        /*Metoda biblioteczna - odpowiedzialna za obliczenie współrzędnych piksela bitmapy wejściowej który będzie
        jednym z dwóch źródeł koloru dla przetwarzanego piksela bitmapy wyjściowej. Metoda jest zawsze wywoływana
            dwukrotnie - dla obliczenia piksela-źródła z pierwszej i drugiej bitmapy wejściowej.*/
        public int[] calcPoint(int resX, int resY, int max, int[,] relDist, int[,] outputCharPoints)
        {
            double[] total = new double[2] { 0, 0};
            double actualDenom = 0;
            double cumulatedDenom = 0;
            int[] toReturn = new int[2];
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
            if (cumulatedDenom != 0)
            {
                total[0] = total[0] / cumulatedDenom;
                total[1] = total[1] / cumulatedDenom;
            }
            toReturn[0] = System.Convert.ToInt32(total[0]);
            toReturn[1] = System.Convert.ToInt32(total[1]);

            return toReturn;
        }

    }
}


