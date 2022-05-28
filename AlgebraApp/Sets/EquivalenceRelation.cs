using System;
using System.Collections.Generic;
using System.Text;

namespace AlgebraApp.Sets
{
    public class EquivalenceRelation<Element> : Relation<Element>
    {

        public bool Contains(Pair<Element> pair)
        {
            // symmetry
            if(this.Contains(new Pair<Element>(pair.y, pair.x)))
            {
                return true;
            }

            // transitivity
            var xzPair = Q.exists<Pair<Element>>();
            var zyPair = Q.exists<Pair<Element>>();
            
            // to be continued.....
        }

    }
}
