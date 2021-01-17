using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ImageMorphing
{
    class AssemblyMorphing
    {
        const string ASM_DLL_Path =
    "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ASMTest/x64/Release/ASMTest.dll";
        [DllImport(@ASM_DLL_Path)]
      private  static extern double CalcNumerator(int[] result, int[] relDist, int[] outputCharPoints,
    int resX, int resY, int max);

        public int[] AssemblyMorpher(int[] relDist, int[] outputCharPoints,
    int resX, int resY, int max)
        {
            int[] result = new int[2];
            CalcNumerator(result, relDist, outputCharPoints, resX, resY, max);
            return result;
        }
    }
}
