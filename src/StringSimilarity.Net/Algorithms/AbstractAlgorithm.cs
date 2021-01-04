using StringSimilarity.Net.Comparators;
using StringSimilarity.Net.StringSplits;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringSimilarity.Net.Algorithms
{
    public abstract class AbstractAlgorithm
    {
        private readonly IStringSplit StringSplit;
        private readonly IComparator Comparator;

        public AbstractAlgorithm(IStringSplit split, IComparator comparator)
        {
            StringSplit = split;
            Comparator = comparator;
        }

        public AbstractAlgorithm(IStringSplit split) : this(split, new EqualityComparator())
        {
        }

        public AbstractAlgorithm(IComparator comparator) : this(new CharactersSplit(), comparator)
        {
        }

        public AbstractAlgorithm() : this(new CharactersSplit(), new EqualityComparator())
        {
        }

        public IDifference Diff(string str1, string str2)
        {
            return Diff(StringSplit.Split(str1), StringSplit.Split(str2));
        }

        protected abstract IDifference Diff(ISequence sequence1, ISequence sequence2);

        protected int ScoreRange
        {
            get
            {
                return Comparator.Range;
            }
        }

        protected double Compare(IStringElement e1, IStringElement e2)
        {
            return Comparator.Compare(e1, e2);
        }
    }
}
