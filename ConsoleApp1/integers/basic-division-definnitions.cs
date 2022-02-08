using System;

namespace ConsoleApp1 {

    class BasicDivisionDefinitions
    {
        public static bool divides(
          int d, // 4
          int n // 8
        )
        {
            try
            {
                BasicDivisionDefinitions.existsDivision(d, n);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool multiple(int n, int d)
        {
            return BasicDivisionDefinitions.divides(d, n);
        }

        public static int existsDivision(
          int d, // 4
          int n  // 8
        )
        {
            var oneMore = Q.exist(); // 56
            I.True(n == d * oneMore);
            return oneMore;
        }

        public static bool isProperDivisor(int d, int n)
        {
            return d != n && d != -n && d != 1 && d != -1 && BasicDivisionDefinitions.divides(d, n);
        }
        public static bool isPrime(int p)
        {
            var divisor = Q.any();
            return p > 1 && !BasicDivisionDefinitions.isProperDivisor(divisor, p);
        }
    }

    class Prime
    {
        public int p;

        public Prime(int p)
        {
            I.True(BasicDivisionDefinitions.isPrime(p));
            this.p = p;
        }
    }

    class PositivePrime
    {
        public int p;
        public PositivePrime(int p)
        {
            I.True(BasicDivisionDefinitions.isPrime(p) && p > 0);
            this.p = p;
        }
    }


}