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
