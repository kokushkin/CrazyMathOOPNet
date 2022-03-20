using System;
using System.Collections.Generic;
using System.Text;

namespace AlgebraApp.Numbers
{
    class PositiveInteger : NotZeroInteger
    {
        public PositiveInteger(int n) : base(n)
        {
            I.True(n > 0);
        }

        public static PositiveInteger operator +(PositiveInteger a, PositiveInteger b)
            => new PositiveInteger(a.n + b.n);
    }

}
