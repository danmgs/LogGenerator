using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogGenerator
{
    internal static class RandomGen
    {
        public static int GenerateRandomLevelNumber(int iStart, int iEnd)
        {
            Random r = new Random();
            int rInt = r.Next(iStart, iEnd);
            return rInt;
        }

        public static double GenerateRandomTimeEllapse(int iRange)
        {
            Random r = new Random();
            double rDouble = r.NextDouble() * iRange;
            return Math.Round(rDouble, 3);
        }
    }
}
