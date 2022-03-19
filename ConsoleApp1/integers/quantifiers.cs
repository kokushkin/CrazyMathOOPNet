using System;

namespace ConsoleApp1
{
    class Q
    {
        public static Integer any()
        {
            Random rnd = new Random();
            return rnd.Next();
        }

        public static Integer exist()
        {
            Random rnd = new Random();
            return rnd.Next();
        }

        public static Rational rationalExist()
        {
            Random rnd = new Random();
            var a = rnd.Next();
            var b = rnd.Next();
            return new Rational(a, IntegerMath.Abs(b));
        }

  
        public static T assume<T>(T x)
        {
            return x;
        }

        // static existq(quatifier: (...params: number[]) => unknown) {
        //   return quatifier;
        // }

        // static anyq(quatifier: (...params: number[]) => unknown) {
        //   return quatifier;
        // }
    }
}
