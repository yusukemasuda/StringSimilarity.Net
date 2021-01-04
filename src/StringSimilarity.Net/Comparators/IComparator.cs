using System;
using System.Collections.Generic;
using System.Text;

namespace StringSimilarity.Net.Comparators
{
    public interface IComparator
    {
        int Range { get; }

        double Compare(IStringElement e1, IStringElement e2);
    }
}
