using System;
using System.Collections.Generic;
using System.Text;
using AlgebraApp.Numbers;

namespace AlgebraApp
{
    class IntegerMath
    {
        public static PositiveInteger Abs(Integer n)
        {
            return new PositiveInteger(Math.Abs((int)n));
        }

        public static Rational Sqrt(Rational n)
        {
            var some = Q.exists<Rational>();
            I.True(n == some * some);
            return some;
        }

    }
}
