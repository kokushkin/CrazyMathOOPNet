using System;
using System.Collections.Generic;
using System.Text;

namespace AlgebraApp.Numbers
{
    class Prime : PositiveInteger
    {
        public Prime(int n) : base(n)
        {
            I.True(BasicDivisionDefinitions.isPrime(n));
        }

        public Prime(Integer n) : base((int)n)
        {
            I.True(BasicDivisionDefinitions.isPrime(n));
        }
    }

}
