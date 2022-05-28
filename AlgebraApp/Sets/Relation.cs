using System;
using System.Collections.Generic;
using System.Text;

namespace AlgebraApp.Sets
{

    public class Pair<Element>
    {
        public Element x;
        public Element y;

        public Pair(Element x, Element y)
        {
            this.x = x;
            this.y = y;
        }

    }


    

    public class Relation<Element>: Set<Pair<Element>>
    {


    }
}
