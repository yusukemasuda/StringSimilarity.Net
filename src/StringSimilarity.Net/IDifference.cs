using System;
using System.Collections.Generic;
using System.Text;

namespace StringSimilarity.Net
{
    public interface IDifference
    {
        ISequence Sequence1 { get; }

        ISequence Sequence2 { get; }

        double Similarity { get; }
    }
}
