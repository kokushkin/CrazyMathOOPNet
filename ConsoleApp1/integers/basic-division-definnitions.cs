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
    }


}