using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ImageMorphing
{
    /*Klasa odpowiedzialna za obsługę funkcji biblioteki DLL w języku MASM*/
    class AssemblyMorphing
    {
        /*Obiekt synchronizujący dostęp do metody*/
        static readonly object _locker = new object();

        /*Ścieżka do biblioteki DLL*/
        const string ASM_DLL_Path =
    "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ASMTest/x64/Release/ASMTest.dll";
        [DllImport(@ASM_DLL_Path)]

        /*Funkcja biblioteczna - odpowiedzialna za obliczenie współrzędnych piksela bitmapy wejściowej który będzie
         jednym z dwóch źródeł koloru dla przetwarzanego piksela bitmapy wyjściowej. Funkcja jest zawsze wywoływana
        dwukrotnie - dla obliczenia piksela-źródła z pierwszej i drugiej bitmapy wejściowej.*/
      private  static extern double CalcNumerator(int[] result, int[] relDist, int[] outputCharPoints,
    int resX, int resY, int max);

        /*Metoda wywołująca funkcję biblioteczną, synchronizując dostęp do niej pomiędzy wątkami i zwraca jej wynik*/
        public int[] AssemblyMorpher(int[] relDist, int[] outputCharPoints,
    int resX, int resY, int max)
        {
            int[] result = new int[2];
            lock(_locker)
            {
                CalcNumerator(result, relDist, outputCharPoints, resX, resY, max);
            }
            return result;
        }
    }
}
