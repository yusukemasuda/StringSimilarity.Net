namespace StringSimilarity.Net
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    public class SequenceBuilder
    {
        private readonly ICollection<IStringElement> Elements;

        public SequenceBuilder(IEnumerable<IStringElement> elements)
        {
            Elements = elements.ToList();
        }

        public SequenceBuilder() : this(new Collection<IStringElement>())
        {
        }

        public void Add(IStringElement element)
        {
            Elements.Add(element);
        }

        public string Original { private get; set; }

        public ISequence Build()
        {
            var sequence = new Sequence(Elements);
            sequence.Original = Original;
            return sequence;
        }
    }
}
