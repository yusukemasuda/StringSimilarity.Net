using System;
using System.Collections.Generic;
using System.Text;

namespace StringSimilarity.Net
{
    public class StringElementBuilder
    {
        public string Term { private get; set; }

        public int Offset { private get; set; }

        public int Length { private get; set; }

        public IStringElement Build()
        {
            return new StringElement
            {
                Term = this.Term,
                Offset = this.Offset,
                Length = this.Length
            };
        }
    }
}
