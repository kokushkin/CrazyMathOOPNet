using System;
using System.Collections.Generic;
using AlgebraApp.Numbers;

namespace AlgebraApp
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
            NotZeroInteger m
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

            var _r = Q.assume(Q.exists<Integer>());
            var _q = Q.assume(Q.exists<Integer>());
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
                var d = Q.any<Integer>();
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
            var n = Q.any<NotZeroInteger>();
            var d = Q.exists<NotZeroInteger>();
            var e = Q.exists<NotZeroInteger>();

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
                  (n / e) <= (n / d),
                  d <= n / d,
                  (d^2) <= n,
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

        public class XYForm: NotZeroInteger
        {
              new Integer n;
              Integer m;
              public Integer x;
              public Integer y;
            public XYForm(Integer n, Integer m, Integer x, Integer y, NotZeroInteger d): base(d)
            {
     
                I.True(this == x * m + y * n);

                this.n = n;
                this.m = m;
                this.x = x;
                this.y = y;
            }
        }

        static XYForm existsOnlyOneLeastPositiveXYForm(Integer n, NotZeroInteger m) {
            var x1 = Q.any<Integer>();
            var y1 = Q.any<Integer>();
            var x = Q.exists<Integer>();
            var y = Q.exists<Integer>();
            var d = x * m + y * n;
            I.True(d > 0 && d <= x1 * m + y1 * n);

            return new XYForm(n, m, x, y, (NotZeroInteger)d);
        }

        public static XYForm existsOnlyOneGCD(Integer n, NotZeroInteger m) 
        {
 
            var D = existsOnlyOneLeastPositiveXYForm(n, m);
            var x = D.x;
            var y = D.y;

            var d = Q.any<Integer>();
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

            return D;
            // how to tell that it's unique?
        }

        Integer existOnlyOneLeastCommonMultiple(Integer n, NotZeroInteger m) {
            
            var gcd = existsOnlyOneGCD(n, m);
            var a = gcd.x;
            var b = gcd.y;

            var n_ = BasicDivisionDefinitions.existsDivision(gcd, n);
            var m_ = BasicDivisionDefinitions.existsDivision(gcd, m);

            I.True(n == n_ * gcd);
            I.True(m == m_ * gcd);
            // todo: How to make it better then .a ?
            var L = ((n * m) / gcd).a;
            I.functionsChain(L, (n * m) / gcd, (n_ * gcd * m) / gcd, n_ * m);
            I.functionsChain(L, (n * m) / gcd, (n * m_ * gcd) / gcd, n * m_);
            I.True(L == n_ * m && L == n * m_);

            var M = Q.assume(Q.exists<Integer>());
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

        // finds which factor of a product divided by a divisor
        // 8 = 4x2
        // p 
        // 0 = 4x0
        // p = 7
        public static Integer getDividentFactor(
              Prime dvsr, // divisor of the product  2
              Integer fctr1, // first factor of the product  4
              Integer fctr2 // second factor of the product  2
            ) {

            if (BasicDivisionDefinitions.divides(dvsr, fctr1))
            {
                return fctr1;
            }
            else
            {
                var gcd = existsOnlyOneGCD(
                  fctr1,
                  new NotZeroInteger((int)dvsr)
                );
                var s = gcd.x;
                var r = gcd.y;

                I.True(gcd != dvsr);
                I.True(gcd == 1);
                var k = BasicDivisionDefinitions.existsDivision(dvsr, fctr1 * fctr2);
                I.True(k * dvsr == fctr1 * fctr2);
                I.functionsChain(
                  fctr2,
                  fctr2 * 1,
                  fctr2 * (r * dvsr + s * fctr1),
                  fctr2 * r * dvsr + s * fctr1 * fctr2,
                  fctr2 * r * dvsr + s * k * dvsr,
                  dvsr * (r * fctr2 + s * k)
                );
                I.True(BasicDivisionDefinitions.divides(dvsr, fctr2));
                return fctr2;
            }
        }

        

    }


}