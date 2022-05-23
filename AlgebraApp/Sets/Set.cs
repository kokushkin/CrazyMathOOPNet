using System;
using System.Collections.Generic;
using System.Text;

namespace AlgebraApp.Sets
{
    // TODO: Get rid of the EqualityComparer somehow (define our own simpler interface?)
    // TODO: what if it dont need any definitions and Set = Type and
    // Contains and IsSubsetOf is "typeof" and "inherits from"?
    internal class Set<Element> where Element: EqualityComparer<Element>
    {

        public bool IsSubsetOf<AnotherSet>(AnotherSet anotherSet)
        {
            // based on idea of subtypes
            if(this is AnotherSet)
            {
                return true;
            }

            return false;
        }

        public bool Contains(Element someElement)
        {
            // TODO: how to say that it's from the Set?
            // TODO: also could be based on idea of subtypes
            var element = Q.exists<Set<Element>>();
            if(element == someElement)
            {
                return true;
            }
            return false;

        }
    }
}
