using System.Linq;
using System.Collections.Generic;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        public static double[,] MedianFilter(double[,] original)
        {
            int lenX, lenY;
            lenX = original.GetLength(0);
            lenY = original.GetLength(1);
            double[,] resultingArray = new double[lenX,lenY];
            return Selector(original, resultingArray, lenX, lenY);
        }

        public static double[,] Selector(double[,] original, double[,] resultingArray, 
                                        int lenX, int lenY)
        {
            if (lenX == lenY && lenX == 1)
                return original;
            else if (lenX == 1)
                return YDimentionalArray(original, resultingArray, lenY);
            else if (lenY == 1)
                return XDimentionalArray(original, resultingArray, lenX);
            else
                return XYDimentionalArray(original, resultingArray, lenX, lenY);
        }

        public static double[,] XDimentionalArray(double[,] original, double[,] resultingArray,
                                                  int lenX)
        {
            for (int x = 0; x < lenX; x++)
                if (x == 0)
                    resultingArray[x, 0] = MiddleMediane(original[x, 0], original[x + 1, 0]);
                else if (x == lenX - 1)
                    resultingArray[x, 0] = MiddleMediane(original[x, 0], original[x - 1, 0]);
                else
                    resultingArray[x, 0] = MiddleMediane(original[x, 0], original[x - 1, 0],
                                                         original[x + 1, 0]);
            return resultingArray;
        }

        public static double[,] YDimentionalArray(double[,] original, double[,] resultingArray,
                                                  int lenY)
        {
            for (int y = 0; y < lenY; y++)
                if (y == 0)
                    resultingArray[0, y] = MiddleMediane(original[0, y], original[0, y + 1]);
                else if (y == lenY - 1)
                    resultingArray[0, y] = MiddleMediane(original[0, y], original[0, y - 1]);
                else
                    resultingArray[0, y] = MiddleMediane(original[0, y], original[0, y - 1],
                                                         original[0, y + 1]);
            return resultingArray;
        }

        public static double[,] XYDimentionalArray(double[,] original, double[,] resultingArray,
                                                   int lenX, int lenY)
        {
            for (int x = 0; x < lenX; x++)
                for (int y = 0; y < lenY; y++)
                {
                    if (x == 0 && y == 0)
                        resultingArray[x, y] = MiddleMediane(original[x, y], original[x + 1, y],
                                                             original[x, y + 1], original[x + 1, y + 1]);
                    else if (x == lenX - 1 && y == lenY - 1)
                        resultingArray[x, y] = MiddleMediane(original[x, y], original[x - 1, y],
                                                             original[x, y - 1], original[x - 1, y - 1]);
                    else if (x == 0 && y == lenY - 1)
                        resultingArray[x, y] = MiddleMediane(original[x, y], original[x, y - 1],
                                                             original[x + 1, y], original[x + 1, y - 1]);
                    else if (x == lenX - 1 && y == 0)
                        resultingArray[x, y] = MiddleMediane(original[x, y], original[x - 1, y],
                                                             original[x - 1, y + 1], original[x, y + 1]);
                    else if (x == 0)
                        resultingArray[x, y] = MiddleMediane(original[x, y], original[x, y - 1],
                                                             original[x, y + 1], original[x + 1, y],
                                                             original[x + 1, y + 1], original[x + 1, y - 1]);
                    else if (y == 0)
                        resultingArray[x, y] = MiddleMediane(original[x, y], original[x + 1, y],
                                                             original[x - 1, y], original[x, y + 1],
                                                             original[x + 1, y + 1], original[x - 1, y + 1]);
                    else if (x == lenX - 1)
                        resultingArray[x, y] = MiddleMediane(original[x, y], original[x, y - 1],
                                                             original[x, y + 1], original[x - 1, y],
                                                             original[x - 1, y + 1], original[x - 1, y - 1]);
                    else if (y == lenY - 1)
                        resultingArray[x, y] = MiddleMediane(original[x, y], original[x + 1, y],
                                                             original[x - 1, y], original[x, y - 1],
                                                             original[x + 1, y - 1], original[x - 1, y - 1]);
                    else
                        resultingArray[x, y] = MiddleMediane(original[x, y], original[x - 1, y], original[x + 1, y],
                                                             original[x, y + 1], original[x, y - 1], 
                                                             original[x - 1, y - 1], original[x + 1, y + 1],
                                                             original[x - 1, y + 1], original[x + 1, y - 1]);
                }
            return resultingArray;
        }


        public static double MiddleMediane(params double[] parameters)
        {
            System.Array.Sort(parameters);
            double middle;
            int lenOfMass = parameters.Length, devider = lenOfMass / 2;
            if (lenOfMass % 2 == 0)
                middle = (parameters[devider - 1] + parameters[devider]) / 2;
            else middle = parameters[devider];
            return middle;
        }
    }
}
        /*
        public static double[,] MedianFilter(double[,] original)
        {
            int lenX = original.GetLength(0);
            int lenY = original.GetLength(1);
            double[,] returningArr = new double[lenX, lenY];
            if (lenY == 1 && lenX == 1)
                return original;
            else if (lenX == 1)
                return XLineArrayOne(lenY, original, returningArr);
            else if (lenY == 1)
                return YLineArrayOne(lenX, original, returningArr);
            else
                return BigPicture(lenX, lenY, original, returningArr);
        }

        public static double[,] BigPicture(int lenX, int lenY, double[,] original, 
                                           double[,] returningArr)

        {
            for (int x = 0; x < lenX; x++)
                for (int y = 0; y < lenY; y++)
                {
                    if (x == 0 && y == 0)
                        returningArr[0, 0] = NineCorners(original[0, 1],original[1, 0], 
                                                         original[1, 1]);
                    else if (x == 0 && y == (lenY - 1))
                        returningArr[0, lenY - 1] = NineCorners(original[1, lenY - 1],
                                                                original[0, lenY - 2],
                                                                original[1, lenY - 2]);
                    else if (x == (lenX - 1) && y == (lenY - 1))
                        returningArr[lenX - 1, lenY - 1] = NineCorners(original[lenX - 1, lenY - 2],
                                                                       original[lenX - 2, lenY - 2],
                                                                       original[lenX - 2, lenY - 1]);
                    else if (y == 0 && x == (lenX - 1))
                        returningArr[lenX - 1, 0] = NineCorners(original[lenX - 1, 1],
                                                                original[lenX - 2, 0],
                                                                original[lenX - 2, 1]);
                    else if (x == 0)
                        returningArr[x, y] = NineCorners(original[x, y - 1],
                                                         original[x, y + 1],
                                                         original[x + 1, y - 1],
                                                         original[x + 1, y], 
                                                         original[x + 1, y + 1]);
                    else if (y == 0)
                        returningArr[x, y] = NineCorners(original[x - 1, y], original[x + 1, y],
                                                         original[x + 1, y + 1],
                                                         original[x - 1, y + 1],
                                                         original[x + 1, y + 1]);
                    else if (x == lenX - 1)
                        returningArr[x, y] = NineCorners(original[x, y - 1], original[x, y + 1],
                                                         original[x - 1, y - 1],
                                                         original[x - 1, y + 1],
                                                         original[x - 1, y]);
                    else if (y == lenY - 1)
                        returningArr[x, y] = NineCorners(original[x - 1, y], original[x + 1, y],
                                                         original[x + 1, y - 1],
                                                         original[x - 1, y - 1],
                                                         original[x, y - 1]);
                    else
                        returningArr[x, y] = NineCorners(original[x, y + 1],
                                                         original[x, y - 1],
                                                         original[x + 1, y],
                                                         original[x - 1, y], original[x - 1, y - 1],
                                                         original[x + 1, y + 1],
                                                         original[x + 1, y - 1],
                                                         original[x - 1, y + 1]);
                }
            return returningArr;
        }

        public static double[,] XLineArrayOne(int lenY, double[,] original, double[,] returningArr)
        {
            for(int y = 0; y < lenY; y++)
                if (y == 0)
                    returningArr[0, y] = NineCorners(original[0, y], original[0, y + 1]);
                else if(y == lenY - 1)
                    returningArr[0, y] = NineCorners(original[0, y], original[0, y - 1]);
                else
                    returningArr[0, y] = NineCorners(original[0, y], original[0, y - 1],
                                                     original[0, y + 1]);
            return returningArr;
        }

        public static double[,] YLineArrayOne(int lenX, double[,] original, double[,] returningArr)
        {
            for (int x = 0; x < lenX; x++)
                if (x == 0)
                    returningArr[x, 0] = NineCorners(original[x, 0], original[x + 1, 0]);
                else if (x == lenX - 1)
                    returningArr[x, 0] = NineCorners(original[x, 0], original[x - 1, 0]);
                else
                    returningArr[x, 0] = NineCorners(original[x, 0], original[x - 1, 0],
                                                     original[x + 1, 0]);
            return returningArr;
        }
       
        public static double NineCorners(params double[] doub)
        {
            return doub.Sum() / doub.Length;
        }
         */



/*
using System.Linq;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        public static double[,] MedianFilter(double[,] original)
        {
            int lenX = original.GetLength(0);
            int lenY = original.GetLength(1);
            double[,] returningArr = new double[lenX, lenY];
            if (lenY == 1 && lenX == 1)
                return original;
            else if (lenX == 1)
                return XLineArrayOne(lenY, original, returningArr);
            else if (lenY == 1)
                return YLineArrayOne(lenX, original, returningArr);
            else
                return BigPicture(lenX, lenY, original, returningArr);
        }

        public static double[,] BigPicture(int lenX, int lenY, double[,] original, 
                                           double[,] returningArr)

        {
            for (int x = 0; x < lenX; x++)
                for (int y = 0; y < lenY; y++)
                {
                    if (x == 0 && y == 0)
                        returningArr[0, 0] = NineCorners(original[0, 0], original[0, 1],
                                                         original[1, 0], original[1, 1]);
                    else if (x == 0 && y == (lenY - 1))
                        returningArr[0, lenY - 1] = NineCorners(original[0, lenY - 1],
                                                                original[1, lenY - 1],
                                                                original[0, lenY - 2],
                                                                original[1, lenY - 2]);
                    else if (x == (lenX - 1) && y == (lenY - 1))
                        returningArr[lenX - 1, lenY - 1] = NineCorners(original[lenX - 1, lenY - 1],
                                                                       original[lenX - 1, lenY - 2],
                                                                       original[lenX - 2, lenY - 2],
                                                                       original[lenX - 2,
                                                                                lenY - 1]);
                    else if (y == 0 && x == (lenX - 1))
                        returningArr[lenX - 1, 0] = NineCorners(original[lenX - 1, 0],
                                                                original[lenX - 1, 1],
                                                                original[lenX - 2, 0],
                                                                original[lenX - 2, 1]);
                    else if (x == 0)
                        returningArr[x, y] = NineCorners(original[x, y - 1],
                                                         original[x, y + 1],
                                                         original[x, y], original[x + 1, y - 1],
                                                         original[x + 1, y], original[x + 1,
                                                                                      y + 1]);
                    else if (y == 0)
                        returningArr[x, y] = NineCorners(original[x - 1, y], original[x + 1, y],
                                                         original[x, y],
                                                         original[x + 1, y + 1],
                                                         original[x - 1, y + 1],
                                                         original[x + 1, y + 1]);
                    else if (x == lenX - 1)
                        returningArr[x, y] = NineCorners(original[x, y - 1], original[x, y + 1],
                                                         original[x, y], original[x - 1, y - 1],
                                                         original[x - 1, y + 1],
                                                         original[x - 1, y]);
                    else if (y == lenY - 1)
                        returningArr[x, y] = NineCorners(original[x - 1, y], original[x + 1, y],
                                                         original[x, y], original[x + 1, y - 1],
                                                         original[x - 1, y - 1], original[x,
                                                                                          y - 1]);
                    else
                        returningArr[x, y] = NineCorners(original[x, y], original[x, y + 1],
                                                         original[x, y - 1],
                                                         original[x + 1, y],
                                                         original[x - 1, y], original[x - 1, y - 1],
                                                         original[x + 1, y + 1],
                                                         original[x + 1, y - 1],
                                                         original[x - 1, y + 1]);
                }
            return returningArr;
        }



        public static double[,] XLineArrayOne(int lenY, double[,] original, double[,] returningArr)
        {
            for(int y = 0; y < lenY; y++)
                if (y == 0)
                    returningArr[0, y] = NineCorners(original[0, y], original[0, y + 1]);
                else if(y == lenY - 1)
                    returningArr[0, y] = NineCorners(original[0, y], original[0, y - 1]);
                else
                    returningArr[0, y] = NineCorners(original[0, y], original[0, y - 1],
                                                     original[0, y + 1]);
            return returningArr;
        }

        public static double[,] YLineArrayOne(int lenX, double[,] original, double[,] returningArr)
        {
            for (int x = 0; x < lenX; x++)
                if (x == 0)
                    returningArr[x, 0] = NineCorners(original[x, 0], original[x + 1, 0]);
                else if (x == lenX - 1)
                    returningArr[x, 0] = NineCorners(original[x, 0], original[x - 1, 0]);
                else
                    returningArr[x, 0] = NineCorners(original[x, 0], original[x - 1, 0],
                                                     original[x + 1, 0]);
            return returningArr;
        }
       
        public static double NineCorners(params double[] doub)
        {
            return doub.Sum() / doub.Length;
        }
    }
}
*/