using System;

namespace KeyworderLib
{
    public class Keyword
    {
        public string CategoryId { get; private set; }

        public string KeywordId { get; private set; }

        public Keyword(string categoryId, string keywordId)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
            {
                throw new ArgumentException("categoryId is required", nameof(categoryId));
            }
            if (string.IsNullOrWhiteSpace(keywordId))
            {
                throw new ArgumentException("KeywordId is required", nameof(keywordId));
            }
            CategoryId = categoryId;
            KeywordId = keywordId;
        }
    }
}
