﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgebraApp.Numbers
{
    class Rational
    {
        public Integer a;
        public NotZeroInteger b;

        public Rational(Integer a, NotZeroInteger b)
        {
            I.True(b > 0);
            this.a = a;
            this.b = b;

        }

        public static Rational operator *(Rational r1, Rational r2)
            => new Rational(r1.a * r2.a, r1.b * r2.b);

        public static Rational operator ^(Rational r, Integer n)
            => new Rational(r.a ^ n, r.b ^ n);

        public static bool operator <(Rational r, Integer i)
            => r.a < i * r.b;

        public static bool operator >(Rational r, Integer i)
            => r.a > i * r.b;

        public static bool operator <(Integer i, Rational r)
            => i * r.b < r.a;

        public static bool operator >(Integer i, Rational r)
            => i * r.b > r.a;

        public static bool operator <=(Rational a, Rational b)
            => a.a * b.b <= b.a * a.b;

        public static bool operator >=(Rational a, Rational b)
            => a.a * b.b >= b.a * a.b;

        public static bool operator <=(Integer i, Rational r)
            => i * r.b <= r.a;

        public static bool operator >=(Integer i, Rational r)
            => i * r.b >= r.a;


        public bool isInLowestTerms()
        {
            return BasicDivisionDefinitions.relativelyPrime(this.a, this.b);
        }

        public Rational getInLowestTerms()
        {
            var a_ = (Integer)(this.a / (IntegerTheorems.existsOnlyOneGreatestCommonDivisorInTheLeastPositiveXYForm(this.a, this.b)).d);
            var b_ = (NotZeroInteger)(this.b / (IntegerTheorems.existsOnlyOneGreatestCommonDivisorInTheLeastPositiveXYForm(this.a, this.b)).d);
            // b_ must be NotZeroInteger actually. existsOnlyOneGreatestCommonDivisorInTheLeastPositiveXYForm must return NotZeroInteger, right?
            return new Rational(a_, b_);

        }

        void primeRootIsNotRational(Prime p)
        {
            try
            {
                // to the contrary
                var c = Q.assume(Q.exist<Rational>());
                I.True(c == IntegerMath.Sqrt(p));
                c = c.getInLowestTerms();
                var a = c.a;
                var b = c.b;
                I.True(a / b == IntegerMath.Sqrt(p));
                I.True((a ^ 2) == p * (b ^ 2));
                I.True(BasicDivisionDefinitions.divides(p, a^2));
                I.True(BasicDivisionDefinitions.divides(p, a));
                var a_ = a / p;
                I.True(a == p * a_);
                I.True((a ^ 2) == ((p * a_) ^ 2));
                I.True(((p * a_) ^ 2) == p * (b ^ 2));
                I.True(p * (a_ ^ 2) == (b ^ 2));
                I.True(BasicDivisionDefinitions.divides(p, b));
                // contradiction
            }
            catch (Exception ex)
            {

            }
        }


    }

}
