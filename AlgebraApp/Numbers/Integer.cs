using System;
using System.Collections.Generic;
using System.Text;

namespace AlgebraApp.Numbers
{
    class Integer : Rational
    {
        protected int n;

        public Integer(int n) : base(n, new NotZeroInteger(1))
        {
            this.n = n;
        }

        public Integer(Integer n): base(n, new NotZeroInteger(1))
        {

        }
        public static Integer operator +(Integer a)
            => a;

        public static Integer operator -(Integer a)
            => new Integer(-a.n);

        public static Integer operator ++(Integer a)
            => new Integer(++a.n);

        public static Integer operator --(Integer a)
            => new Integer(--a.n);

        public static Integer operator +(Integer a, Integer b)
            => new Integer(a.n + b.n);

        public static Integer operator -(Integer a, Integer b)
             => new Integer(a.n - b.n);

        public static Integer operator *(Integer a, Integer b)
            => new Integer(a.n * b.n);

        public static Rational operator /(Integer a, NotZeroInteger b)
            => new Rational(a, b);

        public static Integer operator ^(Integer n, Integer x)
            => (Integer) Math.Pow((int) n, (int) x);

        //public static Integer sqrt()
        //{

        //}


        public static bool operator >(Integer a, Integer b)
            => a.n > b.n;

        public static bool operator <(Integer a, Integer b)
            => a.n < b.n;

        public static bool operator <=(Integer a, Integer b)
            => a.n <= b.n;

        public static bool operator >=(Integer a, Integer b)
            => a.n >= b.n;

        public static bool operator ==(Integer a, Integer b)
            => a.n == b.n;
        public static bool operator !=(Integer a, Integer b)
            => a.n != b.n;


        public static implicit operator Integer(int n) => new Integer(n);

        public static explicit operator int(Integer n) => n.n;

    }
}
