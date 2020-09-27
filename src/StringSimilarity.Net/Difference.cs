using System;
using System.Collections.Generic;
using System.Text;

namespace StringSimilarity.Net
{
    internal class Difference : IDifference
    {
        public ISequence Sequence1 { get; internal set; }

        public ISequence Sequence2 { get; internal set; }

        public double Similarity { get; internal set; }
    }
}
