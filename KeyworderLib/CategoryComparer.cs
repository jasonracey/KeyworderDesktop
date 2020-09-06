using System;
using System.Collections.Generic;

namespace KeyworderLib
{
    public class CategoryComparer : IComparer<Category>
    {
        public int Compare(Category? x, Category? y)
        {
            return string.Compare(x?.CategoryId, y?.CategoryId, StringComparison.Ordinal);
        }
    }
}