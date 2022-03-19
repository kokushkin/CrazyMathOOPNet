using System;

namespace ConsoleApp1 {

    class BasicDivisionDefinitions
    {
        public static bool divides(
          Integer d, // 4
          Integer n // 8
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

        public static bool multiple(Integer n, Integer d)
        {
            return BasicDivisionDefinitions.divides(d, n);
        }

        public static Integer existsDivision(
          Integer d, // 4
          Integer n  // 8
        )
        {
            var oneMore = Q.exist(); // 56
            I.True(n == d * oneMore);
            return oneMore;
        }

        public static bool isProperDivisor(Integer d, Integer n)
        {
            return d != n && d != -n && d != 1 && d != -1 && BasicDivisionDefinitions.divides(d, n);
        }
        public static bool isPrime(Integer p)
        {
            var divisor = Q.any();
            return p > 1 && !BasicDivisionDefinitions.isProperDivisor(divisor, p);
        }

        // n = 10; m=21
        // n = 1o; m= 5;
        public static bool relativelyPrime(Integer m, Integer n)
        {
            var d = Q.any(); // d =5
            if (
              BasicDivisionDefinitions.divides(d, m) &&
              BasicDivisionDefinitions.divides(d, n)
            )
            {
                if (d == -1 || d == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }


}