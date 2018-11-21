using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            int sxLen = sx.GetLength(0);
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            double[,] sy = MatrixTransponeration(sx, sxLen);
            double[,] result = SobleLinear(width, height, sxLen, g, sx, sy);
            return result;
        }

        public static double[,] SobleLinear(int width, int height, int sxLen, 
                                            double[,] g, double[,] sx, double[,] sy)
        {
            int step = sxLen / 2;
            double gx = 0.0, gy = 0.0;
            double[,] testingArray = new double[sxLen, sxLen];
            var result = new double[width, height];
            for(int x = step; x < width - step; x++)
                for (int y = step; y < height - step; y++)
                {
                    testingArray = AdditionalArrayMaker(x, y, sxLen, step, testingArray, g);
                    gx = MatrixGMultyplier(sxLen, testingArray, sx);
                    gy = MatrixGMultyplier(sxLen, testingArray, sy);
                    result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            return result;
        }

        public static double[,] AdditionalArrayMaker(int x, int y, int sxLen, int step,
                                                     double[,] testingArray, double[,] g)
        {
            for(int innerX = 0; innerX < sxLen; innerX++)
                for (int innerY = 0; innerY < sxLen; innerY++)
                    testingArray[innerX, innerY] = g[x - step + innerX, y - step + innerY];
            return testingArray;
        }

        public static double MatrixGMultyplier(int sxLen, double[,] testingArray, double[,] sN)
        {
            double gN = 0.0;
            for(int x = 0; x < sxLen; x++)
                for(int y = 0; y < sxLen; y++)
                    gN += testingArray[x, y] * sN[x, y];
            return gN;
        }

        public static double[,] MatrixTransponeration(double[,] sx, int sxLen)
        {
            double[,] sy = new double[sxLen, sxLen];
            for(int x = 0; x < sxLen; x++)
                for(int y = 0; y < sxLen; y++)
                    sy[y, x] = sx[x, y];
            return sy;
        }
    }
}
