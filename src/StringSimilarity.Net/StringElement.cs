namespace StringSimilarity.Net
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class StringElement : IStringElement
    {
        public string Term { get; set; }

        public int Offset { get; set; }

        public int Length { get; set; }

        public override string ToString()
        {
            return string.Format("'{0}'", Term);
        }
    }
}
