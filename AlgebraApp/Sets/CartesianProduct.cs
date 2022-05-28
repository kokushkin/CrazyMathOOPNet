using System;
using System.Collections.Generic;
using System.Text;


namespace AlgebraApp.Sets
{

    public class CartesianProduct<Element>: Relation<Element> {

        public bool IsSubsetOf(Relation<Element> anotherSet)
        {
            return false;
        }
    }



}
