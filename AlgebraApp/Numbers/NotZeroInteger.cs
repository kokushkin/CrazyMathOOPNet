using System;
using System.Collections.Generic;
using System.Text;

namespace AlgebraApp.Numbers
{
    class NotZeroInteger : Integer
    {
        public NotZeroInteger(int n) : base(n)
        {
            I.True(n != 0);
        }

        public static Integer operator +(NotZeroInteger a, NotZeroInteger b)
            => new Integer(a.n + b.n);

        public static int operator +(NotZeroInteger a, int b)
            => a.n + b;

        public static int operator +(int a, NotZeroInteger b)
            => b + a;

        public static int operator -(NotZeroInteger a, NotZeroInteger b)
            => a.n - b.n;

        public static int operator -(NotZeroInteger a, int b)
            => a.n - b;

        public static int operator -(int a, NotZeroInteger b)
            => a - b.n;

        public static NotZeroInteger operator *(NotZeroInteger a, NotZeroInteger b)
            => new NotZeroInteger(a.n * b.n);

        public static int operator *(NotZeroInteger a, int b)
            => a.n * b;

        public static int operator *(int a, NotZeroInteger b)
            => a * b.n;

        public static NotZeroInteger operator ^(NotZeroInteger n, Integer x)
        {
            return (NotZeroInteger)Math.Pow((int)n, (int)x);
        }
    }

}
