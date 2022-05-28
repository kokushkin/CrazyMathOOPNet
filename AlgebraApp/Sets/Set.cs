using System;
using System.Collections.Generic;
using System.Text;

namespace AlgebraApp.Sets
{
    public class Set<Element>
    {

        public virtual bool IsSubsetOf(Set<Element> anotherSet)
        {
            throw new Exception("No definition for axioms");
        }

        public bool Contains(Element someElement)
        {
            throw new Exception("No definition for axioms");
        }
    }
}
