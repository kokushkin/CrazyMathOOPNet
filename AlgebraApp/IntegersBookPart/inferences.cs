using System;
using AlgebraApp.Numbers;

namespace AlgebraApp
{
    class I
    {
        public static bool logicChain(object[]  predicates)
        {
            foreach (var pred in predicates)
            {
                if (!((bool)pred))
                {
                    throw new Exception("Wrong conclusion");
                }
            }
            return true;
        }

        public static void functionsChain(params object[] functions)
        {
            var i = 0;
            while (i < functions.Length - 1)
            {
                I.True(functions[i] == functions[i + 1]);
            }
        }

        public static bool True(bool predicate)
        {
            if (!predicate)
            {
                throw new Exception("It must be True");
            }
            return true;
        }
    }

}