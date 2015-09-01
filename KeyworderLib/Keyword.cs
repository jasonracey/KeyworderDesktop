using System;

namespace KeyworderLib
{
    public class Keyword
    {
        public Keyword(string category, string text)
        {
            if (string.IsNullOrEmpty(category))
            {
                throw new ArgumentException("category is required", nameof(category));
            }
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("text is required", nameof(text));
            }
            Category = category;
            Text = text;
        }

        public string Category { get; private set; }

        public string Text { get; private set; }
    }
}
