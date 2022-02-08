using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class FactorizationTheorem
    {


        class Factorization
        {
            public int n;
            public int[] primes;
            public int[] exponents;
            public Factorization(int n, int[] primes, int[] exponents)
            {
                for (var i = 0; i < primes.Length - 1; i++)
                {
                    if (primes[i] >= primes[i + 1])
                    {
                        throw new Exception("Primes must be ordered");
                    }
                }
                this.n = n;
                this.primes = primes;
                this.exponents = exponents;
            }

            //
            public Factorization multiply(Factorization fac)
            {
                var primes = this.primes.Union(fac.primes);
                var exponents = new List<int>();
                foreach (var prime in primes)
                {
                    var exponent = 0;
                    if (this.primes.Contains(prime))
                    {
                        exponent += this.exponents[Array.IndexOf(this.primes, prime)];
                    }
                    if (fac.primes.Contains(prime))
                    {
                        exponent += fac.exponents[Array.IndexOf(fac.primes, prime)];
                    }
                    exponents.Add(exponent);
                }

                return new Factorization(this.n * fac.n, primes.ToArray(), exponents.ToArray());
            }

            public int? findDividentFactor(int q)
            {
                if (this.primes.Length == 0) {
                    return null;
                }
                var p1 = this.primes[0];
                var dividend = Integer.existOneDividesOneOfTheFactorsIFFDividesProduct(
                  new Prime(q),
                  p1,
                  this.n / p1
                );

                if (dividend == p1) {
                    return dividend;
                } else
                {
                    this.reduce();
                    return this.findDividentFactor(q);
                }
            }

            public void reduce()
            {
                if (this.exponents[0] > 1)
                {
                    this.exponents[0] = --this.exponents[0];
                }
                else
                {
                    this.primes = this.primes.Skip(1).ToArray();
                    this.exponents = this.exponents.Skip(1).ToArray();

                }
                this.n = this.n / this.primes[0];
            }
        }

        Factorization existsFactorisation(int n)
        {
            if (n == 1)
            {
                return new Factorization(1, new int[] { 1 }, new int[] { 1 });
            }
            // n > 1
            var n1 = Q.any();
            Q.assume(I.True(n1 < n));
            Q.assume(existsFactorisation(n1) != null);

            try
            {
                return existsFactorisation(n);
            }
            catch (Exception ex)
            {
                if (BasicDivisionDefinitions.isPrime(n))
                {
                    var primeUniqueFactorisation = new Factorization(n, new int[] { n }, new int[] { 1 });
                    return primeUniqueFactorisation;
                }

                var x = Q.exist();
                var y = Q.exist();
                I.True(
                  BasicDivisionDefinitions.isProperDivisor(x, n) &&
                    BasicDivisionDefinitions.isProperDivisor(y, n)
                );
                I.True(n == x * y);
                I.True(x < n);
                I.True(y < n);

                var factorisationOfX = existsFactorisation(x);
                var factorisationOfY = existsFactorisation(y);
                var factorisation = factorisationOfX.multiply(factorisationOfY);

                return factorisation; // Contradiction
            }
        }

        void factorisationsAreEqual(
          Factorization qFactorisation,
          Factorization pFactorisation
    
        ) {
            if (
              qFactorisation.primes.Length == 0 &&
              pFactorisation.primes.Length == 0
            )
            {
                return;
            }

            var q1 = qFactorisation.primes[0];
            I.True(BasicDivisionDefinitions.divides(q1, qFactorisation.n));
            I.True(BasicDivisionDefinitions.divides(q1, pFactorisation.n));
            var pi = pFactorisation.findDividentFactor(q1);
            if (pi == null)
            {
                throw new Exception("Contradiction!");
            }
            // becasue q1 and pi are primes
            I.True(q1 == pi);
            var i = Array.IndexOf(pFactorisation.primes, pi);

            if (1 == i)
            {
                //q1 === p1
                //make recursion
                qFactorisation.reduce();
                pFactorisation.reduce();
                factorisationsAreEqual(qFactorisation, pFactorisation);
            }

            // 1 < i
            var p1 = pFactorisation.primes[0];
            I.True(p1 < pi);

            I.True(BasicDivisionDefinitions.divides(p1, qFactorisation.n));
            I.True(BasicDivisionDefinitions.divides(p1, pFactorisation.n));

            var qj = qFactorisation.findDividentFactor(p1);

            if (qj == null)
            {
                throw new Exception("Contradiction!");
            }
            // becasue q1 and pi are primes
            I.True(p1 == qj);
            I.True(qj >= q1);
            I.True(q1 == pi);
            I.True(pi > p1);
            // impossibe
            I.True(p1 > p1);
        }

        Factorization  existsUniqueFactorisation(int n)
        {
            var qFactorisation = existsFactorisation(n);
            var pFactorisation = existsFactorisation(n);
            Q.assume(qFactorisation != pFactorisation);
            factorisationsAreEqual(qFactorisation, pFactorisation);

            //TODO: qFactorisation and pFactorisation were changed!
            return qFactorisation;
        }
    }

}