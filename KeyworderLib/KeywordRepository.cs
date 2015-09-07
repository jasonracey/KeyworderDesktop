using System;
using System.Collections.Generic;
using System.IO;

namespace KeyworderLib
{
    public static class KeywordRepository
    {
        private const string Path = @"Keywords.csv";

        public static void CreateCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException("category is required", nameof(category));
            }
            var keywordString = $"{category},";
            WriteKeywordString(keywordString);
        }

        public static void CreateKeyword(string category, string keyword)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException("category is required", nameof(category));
            }
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new ArgumentException("keyword is required", nameof(keyword));
            }
            var keywordString = $"{category},{keyword}";
            WriteKeywordString(keywordString);
        }

        public static SortedDictionary<string, SortedSet<string>> GetKeywordsGroupedByCategory()
        {
            var keywordsGroupedByCategory = new SortedDictionary<string, SortedSet<string>>();
            foreach (var keywordString in ReadKeywordStrings())
            {
                var parts = keywordString.Split(',');
                var category = parts[0];
                var keyword = parts[1];
                if (!keywordsGroupedByCategory.ContainsKey(category))
                {
                    keywordsGroupedByCategory.Add(category, new SortedSet<string>());
                }
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keywordsGroupedByCategory[category].Add(keyword);
                }
            }
            return keywordsGroupedByCategory;
        }

        private static SortedSet<string> ReadKeywordStrings()
        {
            var keywordStrings = new SortedSet<string>();
            using (var reader = new StreamReader(Path))
            {
                string keywordString;
                while ((keywordString = reader.ReadLine()) != null)
                {
                    keywordStrings.Add(keywordString);
                }
            }
            return keywordStrings;
        }

        private static void WriteKeywordString(string keywordString)
        {
            var keywordStrings = ReadKeywordStrings();
            if (keywordStrings.Contains(keywordString))
            {
                return;
            }
            // if user has assigned a category its first keyword then remove the category placeholder string
            var parts = keywordString.Split(',');
            var haveKeyword = !string.IsNullOrWhiteSpace(parts[1]);
            if (haveKeyword)
            {
                var categoryString = $"{parts[0]},";
                keywordStrings.Remove(categoryString);
            }
            keywordStrings.Add(keywordString);
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
            using (var writer = new StreamWriter(Path))
            {
                foreach (var s in keywordStrings)
                {
                    writer.WriteLine(s);
                }
            }
        }
    }
}