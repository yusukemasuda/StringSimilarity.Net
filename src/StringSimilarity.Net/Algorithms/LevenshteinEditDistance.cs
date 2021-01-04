namespace StringSimilarity.Net.Algorithms
{
    using StringSimilarity.Net.Comparators;
    using StringSimilarity.Net.StringSplits;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// https://gist.github.com/Davidblkx/e12ab0bb2aff7fd8072632b396538560
    /// </summary>
    public class LevenshteinEditDistance : AbstractAlgorithm, IAlgorithm
    {
        public LevenshteinEditDistance(IStringSplit split, IComparator comparator) : base(split, comparator)
        {
        }

        public LevenshteinEditDistance(IStringSplit split) : base(split)
        {
        }

        public LevenshteinEditDistance(IComparator comparator) : base(comparator)
        {
        }

        public LevenshteinEditDistance() : base()
        {
        }

        protected override IDifference Diff(ISequence sequence1, ISequence sequence2)
        {
            var source1Length = sequence1.Count();
            var source2Length = sequence2.Count();

            var matrix = new double[source1Length + 1, source2Length + 1];

            // First calculation, if one entry is empty return full length
            if (source1Length == 0)
                return new DifferenceBuilder
                {
                    Sequence1 = sequence1,
                    Sequence2 = sequence2,
                    Similarity = source2Length
                }.Build();

            if (source2Length == 0)
                return new DifferenceBuilder
                {
                    Sequence1 = sequence1,
                    Sequence2 = sequence2,
                    Similarity = source1Length
                }.Build();

            // Initialization of matrix with row size source1Length and columns size source2Length
            for (var i = 0; i <= source1Length; matrix[i, 0] = i++) { }
            for (var j = 0; j <= source2Length; matrix[0, j] = j++) { }

            // Calculate rows and collumns distances
            for (var i = 1; i <= source1Length; i++)
            {
                for (var j = 1; j <= source2Length; j++)
                {
                    var score = Compare(sequence2.ElementAt(j - 1), sequence1.ElementAt(i - 1));

                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + ScoreRange, matrix[i, j - 1] + ScoreRange),
                        matrix[i - 1, j - 1] + score);
                }
            }
            return new DifferenceBuilder
            {
                Sequence1 = sequence1,
                Sequence2 = sequence2,
                Similarity = matrix[source1Length, source2Length] / (Math.Max(source1Length, source2Length) * ScoreRange * 1.00)
            }.Build();
        }
    }
}
