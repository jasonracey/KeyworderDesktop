using System;
using System.Collections.Generic;

namespace KeyworderLib
{
    public class Category
    {
        private static readonly KeywordComparer _keywordComparer = new KeywordComparer();

        public string CategoryId { get; private set; }

        public ICollection<Keyword> Keywords { get; private set; }

        public Category(string categoryId)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
            {
                throw new ArgumentException("CategoryId is required", nameof(categoryId));
            }
            CategoryId = categoryId;
            Keywords = new SortedSet<Keyword>(_keywordComparer);
        }
    }
}
