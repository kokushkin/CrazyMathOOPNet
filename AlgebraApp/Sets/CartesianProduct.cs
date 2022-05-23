using System;
using System.Collections.Generic;
using System.Text;


namespace AlgebraApp.Sets
{
    internal class Pair<Element>: EqualityComparer<Pair<Element>> 
        where Element : EqualityComparer<Element>
    {
        public Element x;
        public Element y;

        public override  bool Equals(Pair<Element> a, Pair<Element> b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public override int GetHashCode(Pair<Element> obj)
        {
            return 0;
        }

        public Set<Pair<Element>> CartesianProduct;

    }



}
