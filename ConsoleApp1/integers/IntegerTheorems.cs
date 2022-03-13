﻿using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class IntegerTheorems
    {

        bool ifDevidesTwoThenDevidesTheirCombination(
          Integer d,
          Integer x,
          Integer y,
          Integer r,
          Integer s,
          Integer a,
          Integer b
        )
        {
            /// requirements
            if (
              !(
                BasicDivisionDefinitions.divides(d, x) &&
                BasicDivisionDefinitions.divides(d, y)
              )
            )
            {
                throw new Exception("This is initial conditions");
            }
            /// end of requirements

            I.functionsChain(new object[] {
              a * x + b * y,
              a * (r * d) + b * (s * d),
              d * (a * r + b * s)
            });

            return BasicDivisionDefinitions.divides(d, a * x + b * y) == true;
        }

        class ReductionModulo
        {
            Integer n;
            Integer m;
            public Integer r;
            public Integer q;
            public ReductionModulo(Integer n, Integer m, Integer r, Integer q)
            {
                I.True(n == q * m + r && r >= 0 && r <= IntegerMath.Abs(m));
                this.n = n;
                this.m = m;
                this.r = r;
                this.q = q;
            }
        }

        static List<Integer> allNumbers = new List<Integer>();

        static ReductionModulo existsOnlyOneReductionModulo(
            Integer n,
            Integer m
        ) {
            /// proof
            // Proof: Let S be the set of all non-negative integers
            // expressible in the form N − sm for some integer s.
            List<(Integer n, Integer s, Integer m, Integer dif)> specialForms = new List<(Integer n, Integer s, Integer m, Integer dif)>();
            var tpl = (n: new Integer(1), s: new Integer(2), m: new Integer(3));
            (Integer n, Integer s, Integer m , Integer dif ) rform (Integer s) =>
                (n, s, m, dif: n - s * m);
            allNumbers.ForEach((s) => {
                if (rform(s).dif >= 0)
                {
                    specialForms.Add(rform(s));
                }
            });

            // The set S is non-empty
            if (specialForms.Count == 0)
            {
                throw new Exception("Can't be empty.");
            }

            // , so by well-ordering has a least element r = N − qm.
            specialForms.Sort();
            var leatsForm = specialForms[0];
            var q = leatsForm.s;
            // rform(r);

            ReductionModulo existingReductionModulo;
            // Claim that r < |m|.
            if (leatsForm.dif < IntegerMath.Abs(m))
            {
                existingReductionModulo = new ReductionModulo(n, m, leatsForm.dif, q);
            }
            // If not, then
            // still r − |m| ≥ 0,
            else
            {
                I.logicChain(new object[] { leatsForm.dif >= IntegerMath.Abs(m), (leatsForm.dif - IntegerMath.Abs(m)) >= 0 });
                //  and also
                // r − |m| = (N − qm) − |m| = N − (q ± 1)m
                var s1 = q + 1;
                I.functionsChain(new object[] {
                  leatsForm.dif - IntegerMath.Abs(m),
                  n - q * m - IntegerMath.Abs(m),
                  m >= 0 ? n - (q + 1) * m : n - (q - 1) * m,
                  m >= 0 ? n - s1 * m : n - s1 * m
                });

                // (with the sign depending on the sign of m) is still in the set S, contradiction

                var substitution = m >= 0 ? n - (q + 1) * m : n - (q - 1) * m;

                if (specialForms.Exists(form => form.dif == substitution) && substitution < leatsForm.dif)
                {
                    throw new Exception("Contradiction");
                }
                else
                {
                    throw new Exception("Impossible");
                }
            }

            // For uniqueness, suppose that both N = qm + r and N = q′m + r′. Subtract to find
            // r − r′ = m · (q′ − q)
            // Thus, r − r′is a multiple of m. But since −|m| < r − r′ < |m| we have r = r′. And then q = q′.

            var _r = Q.assume(Q.exist());
            var _q = Q.assume(Q.exist());
            var anotherExistingReductionModule = new ReductionModulo(n, m, _r, _q);

            I.functionsChain(new object[] { leatsForm.dif - _r, m * (_q - q) });
            I.logicChain(new object[]{
                0 <= leatsForm.dif && leatsForm.dif < IntegerMath.Abs(leatsForm.dif) && 0 <= _r && _r < IntegerMath.Abs(_r),
              -IntegerMath.Abs(m) < leatsForm.dif - _r && leatsForm.dif - _r < IntegerMath.Abs(m),
              -IntegerMath.Abs(m) < m * (_q - q) && m * (_q - q) < IntegerMath.Abs(m)
            });

            if (m > 0)
            {
                I.logicChain(new object[] {
                  -IntegerMath.Abs(m) < m * (_q - q) && m * (_q - q) < IntegerMath.Abs(m),
                  -IntegerMath.Abs(m) / m < _q - q && _q - q < IntegerMath.Abs(m) / m,
                  -1 < m * (_q - q) && _q - q < 1,
                  _q == q
                });
            }
            else
            {
                I.logicChain(new object[] {
                  -IntegerMath.Abs(m) < m * (_q - q) && m * (_q - q) < IntegerMath.Abs(m),
                  -IntegerMath.Abs(m) / m > _q - q && _q - q > IntegerMath.Abs(m) / m,
                  1 > m * (_q - q) && _q - q > -1,
                  _q == q
                });
            }

            I.logicChain(new object[] { _q == q, leatsForm.dif == _r });

            return existingReductionModulo;
        }

        // A positive integer n is prime if and only if it is not divisible by any of the integers
        // d with 1 < d ≤ √n.

        class NotDivisibleWithLessThanRoot: PositiveInteger
        {
            public NotDivisibleWithLessThanRoot(Integer n): base((int)n)
            {
                var d = Q.any();
                I.True(
                  d <= IntegerMath.Sqrt(n) && !BasicDivisionDefinitions.divides(d, n)
                );

            }
        }

        Prime NotDivisibleWithLessThenRootThenPositivePrime(
            NotDivisibleWithLessThanRoot notDivisblePositive
            )
        {
            // positive integer:
            // divistible  => has  a divisor <= sqrt(n)
            var n = Q.any();
            var d = Q.exist();
            var e = Q.exist();

            if (
              n > 0 &&
              n == d * e &&
              BasicDivisionDefinitions.isProperDivisor(d, n) &&
              BasicDivisionDefinitions.isProperDivisor(e, n) &&
              d <= e
            )
            {
                I.functionsChain(
                  d == n / e,
                  n / e <= n / d,
                  d <= n / d,
                  IntegerMath.Pow(d, 2) <= n,
                  d <= IntegerMath.Sqrt(n)
                );
                // positive integer:
                //not(divistible) i.e. prime  <= has no divisor <= sqrt(n)
                return new Prime(notDivisblePositive);
            }
            else
            {
                throw new Exception("Bad luck");
            }
        }

        NotDivisibleWithLessThanRoot IfPositivePrimeThenNotDivisibleWithLessThenRoot(Prime p)
        {
            // obvious, because of prime
            return new NotDivisibleWithLessThanRoot(p);
        }

        // check if it's prime
        bool trialDivisionPrimeTest(Integer n)
        {
            var maxd = IntegerMath.Sqrt(n);

            for (var i = 2; i <= maxd; i++)
            {
                if (BasicDivisionDefinitions.divides(i, n))
                {
                    return false;
                }
            }
            return true;
        }

        // coprime
        // mutually prime
        bool relativelyPrime(Integer m, Integer n)
        {
            var d = Q.exist();
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
                return false;
            }
        }

        // n = 10; m=21
        // n = 1o; m= 5;
        bool relativelyPrime1(Integer m, Integer n)
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

        bool commonDivisor(Integer d, Integer[] n) {
            foreach (var ni in n) {
                if (!BasicDivisionDefinitions.divides(d, ni))
                {
                    return false;
                }
            }

            return true;
        }

        bool commonMultiple(Integer N, Integer[] n) {
            foreach (var ni in n) {
                if (!BasicDivisionDefinitions.divides(ni, N))
                {
                    return false;
                }
            }

            return true;
        }

        class XYForm
        {
              Integer n;
              Integer m;
              public Integer x;
              public Integer y;
              public NotZeroInteger d;
            public XYForm(Integer n, Integer m, Integer x, Integer y, NotZeroInteger d)
            {
                I.True(d == x * m + y * n);

                this.n = n;
                this.m = m;
                this.x = x;
                this.y = y;
                this.d = d;
            }
        }

        static XYForm existsOnlyOneTheLeastPositiveXYForm(Integer n, NotZeroInteger m) {
            var x1 = Q.any();
            var y1 = Q.any();
            var x = Q.exist();
            var y = Q.exist();
            var d = x * m + y * n;
            I.True(d > 0 && d <= x1 * m + y1 * n);

            return new XYForm(n, m, x, y, (NotZeroInteger)d);
        }

        static XYForm existsOnlyOneGreatestCommonDivisorInTheLeastPositiveXYForm(Integer n, NotZeroInteger m) 
        {
 
            var leastPositiveForm = existsOnlyOneTheLeastPositiveXYForm(n, m);
            var x = leastPositiveForm.x;
            var y = leastPositiveForm.y;
            var D = leastPositiveForm.d;

            var d = Q.any();
            var m_ = Q.assume(BasicDivisionDefinitions.existsDivision(d, n));
            var n_ = Q.assume(BasicDivisionDefinitions.existsDivision(d, m));

            I.functionsChain(
              D,
              x * m + y * n,
              x * (m_ * d) + y * (n_ * d),
              (x * m_ + y * n_) * d
            );

            I.True(BasicDivisionDefinitions.divides(d, D));

            var reductionModule = existsOnlyOneReductionModulo(
              m,
              D
            );
            var q = reductionModule.q;
            var r = reductionModule.r;

            I.functionsChain(
              r,
              m - q * D,
              m - q * (x * m + y * n),
              (1 - q * x) * m + -q * y * n
            );

            var x_ = 1 - q * x;
            var y_ = -q * y;
            I.True(r == x_ * m + y_ * n);

            I.True(r < D);
            I.True(r == 0);
            I.True(BasicDivisionDefinitions.divides(D, m));

            // similarly
            I.True(BasicDivisionDefinitions.divides(D, n));

            return leastPositiveForm;
            // how to tell that it's unique?
        }

        Integer existOnlyOneLeastCommonMultiple(Integer n, NotZeroInteger m) {
            
            var form = existsOnlyOneGreatestCommonDivisorInTheLeastPositiveXYForm(n, m);
            var gcd = form.d;
            var a = form.x;
            var b = form.y;

            var n_ = BasicDivisionDefinitions.existsDivision(gcd, n);
            var m_ = BasicDivisionDefinitions.existsDivision(gcd, m);

            I.True(n == n_ * gcd);
            I.True(m == m_ * gcd);
            var L = (n * m) / gcd;
            I.functionsChain(L, (n * m) / gcd, (n_ * gcd * m) / gcd, n_ * m);
            I.functionsChain(L, (n * m) / gcd, (n * m_ * gcd) / gcd, n * m_);
            I.True(L == n_ * m && L == n * m_);

            var M = Q.assume(Q.exist());
            var s = Q.assume(BasicDivisionDefinitions.existsDivision(n, M));
            var r = Q.assume(BasicDivisionDefinitions.existsDivision(m, M));

            I.True(gcd == a * m + b * n);
            I.functionsChain(gcd, a * m + b * n, a * m_ * gcd + b * n_ * gcd);
            I.True(1 == a * m_ + b * n_);
            I.functionsChain(
              M,
              1 * M,
              (a * m_ + b * n_) * M,
              a * m_ * M + b * n_ * M,
              a * m_ * s * n + b * n_ * r * m,
              (a * s + b * r) * L
            );

            I.True(BasicDivisionDefinitions.multiple(M, L));

            return L;
        }

        public static Integer existOneDividesOneOfTheFactorsIFFDividesProduct(
              Prime p,
              Integer a,
              Integer b
            ) {

            if (BasicDivisionDefinitions.divides(p, a))
            {
                return a;
            }
            else
            {
                var form = existsOnlyOneGreatestCommonDivisorInTheLeastPositiveXYForm(
                  a,
                  new NotZeroInteger((int)p)
                );
                var gcd = form.d;
                var s = form.x;
                var r = form.y;

                I.True(gcd != p);
                I.True(gcd == 1);
                var k = BasicDivisionDefinitions.existsDivision(p, a * b);
                I.True(k * p == a * b);
                I.functionsChain(
                  b,
                  b * 1,
                  b * (r * p + s * a),
                  b * r * p + s * a * b,
                  b * r * p + s * k * p,
                  p * (r * b + s * k)
                );
                I.True(BasicDivisionDefinitions.divides(p, b));
                return b;
            }
        }

    }


}