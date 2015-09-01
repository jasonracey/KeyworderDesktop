using System;
using System.Collections.Generic;

namespace KeyworderLib
{
    public class KeywordComparer : IComparer<Keyword>
    {
        public int Compare(Keyword k1, Keyword k2)
        {
            return k1.Category == k2.Category 
                ? string.Compare(k1.Text, k2.Text, StringComparison.Ordinal) 
                : string.Compare(k1.Category, k2.Category, StringComparison.Ordinal);
        }
    }
}