namespace StringSimilarity.Net.Morphological.StringSplits
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Text;
    using Lucene.Net.Analysis;
    using Lucene.Net.Analysis.Ja;
    using Lucene.Net.Analysis.Ja.Dict;
    using Lucene.Net.Analysis.Ja.TokenAttributes;
    using Lucene.Net.Analysis.TokenAttributes;
    using StringSimilarity.Net.StringSplits;

    public class MorphologicalSplit : IStringSplit
    {
        private readonly UserDictionary UserDictionary;

        public MorphologicalSplit(UserDictionary dict)
        {
            UserDictionary = dict;
        }

        public ISequence Split(string str)
        {
            using (var reader = new StringReader(str))
            {
                var tokenizer = new JapaneseTokenizer(reader, UserDictionary, false, JapaneseTokenizerMode.NORMAL);
                var tokenStreamComponents = new TokenStreamComponents(tokenizer);

                using (var tokenStream = tokenStreamComponents.TokenStream)
                {
                    // 処理の実行前の Reset
                    tokenStream.Reset();

                    var builder = new SequenceBuilder();
                    while (tokenStream.IncrementToken())
                    {
                        builder.Add(new StringElementBuilder
                        {
                            Term = tokenStream.GetAttribute<ICharTermAttribute>().ToString(),
                            Offset = tokenStream.GetAttribute<IOffsetAttribute>().StartOffset,
                            Length = (tokenStream.GetAttribute<IOffsetAttribute>().EndOffset - tokenStream.GetAttribute<IOffsetAttribute>().StartOffset)
                        }.Build());
                    }
                    builder.Original = str;
                    return builder.Build();
                }
            }
        }
    }
}
