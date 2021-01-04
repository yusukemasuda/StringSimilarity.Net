namespace StringSimilarity.Net.Algorithms
{
    using System.Collections.Generic;

    public interface IAlgorithm
    {
        IDifference Diff(string str1, string str2);
    }
}
