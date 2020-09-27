namespace StringSimilarity.Net
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    internal class Sequence : ISequence
    {
        private readonly ICollection<IStringElement> Elements = new Collection<IStringElement>();

        public Sequence() { }

        public Sequence(IEnumerable<IStringElement> elements)
        {
            Elements = Elements.Union(elements).ToList();
        }

        public string Original { get; internal set; }

        internal void Add(IStringElement e)
        {
            Elements.Add(e);
        }

        public int Count()
        {
            return Elements.Count;
        }

        public IStringElement ElementAt(int index)
        {
            return Elements.ElementAt(index);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var e in Elements)
            {
                if (builder.Length > 0)
                {
                    builder.Append(',');
                }
                builder.Append(e.ToString());
            }
            return builder.ToString();
        }
    }
}
