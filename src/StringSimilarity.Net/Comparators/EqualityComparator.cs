using System;
using System.Collections.Generic;
using System.Text;

namespace StringSimilarity.Net.Comparators
{
    public class EqualityComparator : IComparator
    {
        public int Range => 1;

        public double Compare(IStringElement e1, IStringElement e2)
        {
            return (e1?.Term == e2?.Term) ? 0 : 1;
        }
    }
}
