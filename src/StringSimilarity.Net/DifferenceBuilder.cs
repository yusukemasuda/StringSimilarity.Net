using System;
using System.Collections.Generic;
using System.Text;

namespace StringSimilarity.Net
{
    public class DifferenceBuilder
    {
        public ISequence Sequence1 { private get; set; }

        public ISequence Sequence2 { private get; set; }

        public double Similarity { private get; set; }

        public IDifference Build()
        {
            return new Difference
            {
                Sequence1 = this.Sequence1,
                Sequence2 = this.Sequence2,
                Similarity = this.Similarity
            };
        }
    }
}
