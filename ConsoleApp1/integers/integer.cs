using System;

namespace ConsoleApp1
{

    class Integer: Rational
    {
        protected int n;

        public Integer(int n): base(n, new NotZeroInteger(1))
        {
            this.n = n;
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
        {
            return new Rational(a, b);
        }

        public static Integer operator ^(Integer n, Integer x)
        {
            return (Integer)Math.Pow((int)n, (int)x);
        }

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

    class NotZeroInteger: Integer
    {
        public NotZeroInteger(int n): base(n)
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
            => a- b.n;

        public static NotZeroInteger operator *(NotZeroInteger a, NotZeroInteger b)
            => new NotZeroInteger(a.n*b.n);

        public static int operator *(NotZeroInteger a, int b)
            => a.n * b;

        public static int operator *(int a, NotZeroInteger b)
            => a * b.n;

        public static NotZeroInteger operator ^(NotZeroInteger n, Integer x)
        {
            return (NotZeroInteger)Math.Pow((int)n, (int)x);
        }
    }

    class PositiveInteger: NotZeroInteger
    {
        public PositiveInteger(int n): base(n)
        {
            I.True(n > 0);
        }

        public static PositiveInteger operator +(PositiveInteger a, PositiveInteger b)
            => new PositiveInteger(a.n + b.n);
    }

    class Prime: PositiveInteger
    {
        public Prime(int n) : base(n)
        {
            I.True(BasicDivisionDefinitions.isPrime(n));
        }

        public Prime(Integer n): base((int)n)
        {
            I.True(BasicDivisionDefinitions.isPrime(n));
        }
    }


    class Rational
    {
        Integer a;
        NotZeroInteger b;

        public Rational(Integer a, NotZeroInteger b)
        {
            I.True(b > 0);
            this.a = a;
            this.b = b;

        }

        public static Rational operator *(Rational r1, Rational r2)
    => new Rational(r1.a*r2.a, r1.b*r2.b);

        public static Rational operator ^(Rational r, Integer n)
        {
            return new Rational(IntegerMath.Pow(r.a, n), IntegerMath.Pow(r.b, n));
        }


        public bool isInLowestTerms()
        {
            return BasicDivisionDefinitions.relativelyPrime(this.a, this.b);
        }

        public Rational getInLowestTerms()
        {
            var a_ = (Integer)(this.a / (IntegerTheorems.existsOnlyOneGreatestCommonDivisorInTheLeastPositiveXYForm(this.a, this.b)).d);
            var b_ = (NotZeroInteger)(this.b / (IntegerTheorems.existsOnlyOneGreatestCommonDivisorInTheLeastPositiveXYForm(this.a, this.b)).d);
            // b_ must be NotZeroInteger actually. existsOnlyOneGreatestCommonDivisorInTheLeastPositiveXYForm must return NotZeroInteger, right?
            return new Rational(a_, b_);

        }

        void primeRootIsNotRational(Prime p)
        {
            try
            {
                // to the contrary
                var c = Q.assume(Q.rationalExist());
                I.True(c == (IntegerMath.Sqrt(p)));
                c = c.getInLowestTerms();
                var a = c.a;
                var b = c.b;
                I.True(a / b == IntegerMath.Sqrt(p));
                I.True((a^2) == p * (b ^ 2));
                I.True(BasicDivisionDefinitions.divides(p, IntegerMath.Pow(a, 2)));
                I.True(BasicDivisionDefinitions.divides(p, a));
                var a_ = a / p;
                I.True(a == p * a_);
                I.True((a ^ 2) == ((p * a_) ^ 2));
                I.True(((p * a_) ^ 2) == p * (b ^ 2));
                I.True(p* (a_ ^ 2) == (b ^ 2));
                I.True(BasicDivisionDefinitions.divides(p, b));
                // contradiction
            }
            catch(Exception ex)
            {

            }
        }

        
    }

}