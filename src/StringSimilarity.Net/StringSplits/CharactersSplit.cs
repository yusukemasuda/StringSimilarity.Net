namespace StringSimilarity.Net.StringSplits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CharactersSplit : IStringSplit
    {
        public ISequence Split(string str)
        {
            var builder = new SequenceBuilder(str.ToCharArray().Select((c, offset) => new StringElementBuilder
            {
                Term = string.Intern(new string(new char[] { c })),
                Length = 1,
                Offset = offset
            }.Build()).ToList());
            builder.Original = str;
            return builder.Build();
        }
    }
}
