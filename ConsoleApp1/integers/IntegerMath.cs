using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class IntegerMath
    {
        public static PositiveInteger Abs(Integer n)
        {
            return new PositiveInteger(Math.Abs((int)n));
        }

        public static Rational Sqrt(Rational n)
        {
            var some = Q.rationalExist();
            I.True(n == some * some);
            return some;
        }

        public static Integer Pow(Integer n, Integer p)
        {
            return (Integer)Math.Pow((int)n, (int)p);
        }

        public static NotZeroInteger Pow(NotZeroInteger n, Integer p)
        {
            return (NotZeroInteger)Math.Pow((int)n, (int)p);
        }

    }
}
