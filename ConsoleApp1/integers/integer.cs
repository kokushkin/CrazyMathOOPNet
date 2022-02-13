namespace ConsoleApp1
{

    class Integer
    {
        protected int n;

        public Integer(int n)
        {
            this.n = n;
        }

        public static Integer operator +(Integer a, Integer b)
            => new Integer(a.n + b.n);

        public static Integer operator -(Integer a, Integer b)
             => new Integer(a.n - b.n);

        public static Integer operator *(Integer a, Integer b)
            => new Integer(a.n * b.n);

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

        public static NotZeroInteger operator +(NotZeroInteger a, NotZeroInteger b)
            => new NotZeroInteger(a.n + b.n);

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


}