namespace StringSimilarity.Net
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IStringElement
    {
        string Term { get; }

        int Offset { get; }

        int Length { get; }
    }
}
