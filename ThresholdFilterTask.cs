using System.Linq;
using System.Collections.Generic;
using System;

namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
        {
            int lenX = original.GetLength(0), lenY = original.GetLength(1);
            int n = lenX * lenY;
            int whitePixels = (int)(whitePixelsFraction * n);
            double[] experementalArray = ArrayMaker(original, lenX, lenY);
            double numberForFinding = ArrayChecker(experementalArray, whitePixels);
            return WhiteBlackMaker(original, numberForFinding, lenX, lenY, whitePixels);
        }

        public static double[] ArrayMaker(double[,] original, int lenX, int lenY)
        {
            double[] arrayOfOriginal = new double[lenX * lenY];
            int i = 0;
            for (int x = 0; x < lenX; x++)
                for (int y = 0; y < lenY; y++)
                {
                    arrayOfOriginal[i] = original[x, y];
                    ++i;
                }
            return arrayOfOriginal;
        }

        public static double ArrayChecker(double[] experementalArray, int whitePixels)
        {
            Array.Sort(experementalArray);
            Array.Reverse(experementalArray);
            int whitePixel = (whitePixels < 1) ? 0 : whitePixels - 1;
            double numberForFinding = experementalArray[whitePixel]; ;
            return numberForFinding;
        }

        public static double[,] WhiteBlackMaker(double[,] original, double numberForFinding,
                                                int lenX, int lenY, int whitePixels)
        {
            double[,] returningArray = new double[lenX, lenY];
            for (int x = 0; x < lenX; x++)
                for (int y = 0; y < lenY; y++)
                {
                    if (original[x, y] >= numberForFinding && whitePixels != 0)
                        returningArray[x, y] = 1.0;
                    else
                        returningArray[x, y] = 0.0;
                }
            return returningArray;
        }
    }
}
