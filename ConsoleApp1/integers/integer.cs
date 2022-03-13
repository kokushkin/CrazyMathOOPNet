namespace ConsoleApp1
{

    class Integer
    {
        protected int n;

        public Integer(int n)
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

        public static Integer operator /(Integer a, Integer b)
        {
            // makes compilation weeker
            // as an alternative, retrun Rational or nullable Interger
            // with an explicit conversion in place
            return BasicDivisionDefinitions.existsDivision(a, b);
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


}