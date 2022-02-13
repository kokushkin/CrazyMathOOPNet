using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class IntegerMath
    {
        public static Integer Abs(Integer n)
        {
            return Math.Abs((int)n);
        }

        public static Integer Sqrt(Integer n)
        {
            var some = Q.exist();
            I.True(n == some * some);
            return some;
        }

        public static Integer Pow(Integer n, Integer p)
        {
            return (Integer)Math.Pow((int)n, (int)p);
        }
    }
}
