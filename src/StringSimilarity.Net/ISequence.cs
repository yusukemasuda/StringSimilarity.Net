using System;
using System.Collections.Generic;
using System.Text;

namespace StringSimilarity.Net
{
    public interface ISequence
    {
        string Original { get; }

        int Count();

        IStringElement ElementAt(int index);
    }
}
