namespace StringSimilarity.Net.StringSplits
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IStringSplit
    {
        ISequence Split(string str);
    }
}
