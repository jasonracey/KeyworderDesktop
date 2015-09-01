using System.Collections.Generic;
using System.IO;

namespace KeyworderLib
{
    public static class KeywordRepository
    {
        private const string Repository = @"keywords.csv";

        public static SortedDictionary<string, SortedSet<string>> GetKeywordsGroupedByCategory()
        {
            var keywordsGroupedByCategory = new SortedDictionary<string, SortedSet<string>>();

            foreach (var keyword in ReadKeywords())
            {
                if (!keywordsGroupedByCategory.ContainsKey(keyword.Category))
                {
                    keywordsGroupedByCategory.Add(keyword.Category, new SortedSet<string>());
                }
                keywordsGroupedByCategory[keyword.Category].Add(keyword.Text);
            }

            return keywordsGroupedByCategory;
        }

        public static void WriteKeyword(Keyword keyword)
        {
            var keywords = ReadKeywords();
            if (keywords.Contains(keyword))
            {
                return;
            }
            keywords.Add(keyword);
            keywords.Sort(new KeywordComparer());
            if (File.Exists(Repository))
            {
                File.Delete(Repository);
            }
            using (var writer = new StreamWriter(Repository))
            {
                foreach (var item in keywords)
                {
                    writer.WriteLine($"{item.Category},{item.Text}");
                }
            }
        }

        private static List<Keyword> ReadKeywords()
        {
            var keywords = new List<Keyword>();
            using (var reader = new StreamReader(Repository))
            {
                string keywordString;
                while ((keywordString = reader.ReadLine()) != null)
                {
                    var parts = keywordString.Split(',');
                    keywords.Add(new Keyword(parts[0], parts[1]));
                }
            }
            return keywords;
        }
    }
}