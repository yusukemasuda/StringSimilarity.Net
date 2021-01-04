using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StringSimilarity.Net.Comparators
{
    public class WeightingComparator : IComparator
    {
        private readonly IReadOnlyDictionary<string, double> WeightCoefficients;

        private readonly IComparator Comparator;

        public WeightingComparator(IComparator comparator, IDictionary<string, double> weightCoefficients)
        {
            Comparator = comparator;
            WeightCoefficients = new ReadOnlyDictionary<string, double>(weightCoefficients);
        }

        public int Range => Comparator.Range;

        public double Compare(IStringElement e1, IStringElement e2)
        {
            var term = e1.Term;
            var score = Comparator.Compare(e1, e2);
            if (score == 0 && WeightCoefficients.ContainsKey(term))
            {
                double weightCoefficient;
                if (WeightCoefficients.TryGetValue(term, out weightCoefficient))
                {
                    return (weightCoefficient * Range);
                }
            }
            return score;
        }
    }
}
