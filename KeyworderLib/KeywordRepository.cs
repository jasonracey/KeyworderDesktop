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
            var keywordStrings = ReadKeywordStrings();
            if (keywordStrings.Contains(keywordString))
            {
                return;
            }
            keywordStrings.Add(keywordString);
            WriteKeywordStrings(keywordStrings);
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
            var keywordStrings = ReadKeywordStrings();
            if (keywordStrings.Contains(keywordString))
            {
                return;
            }
            // if user has assigned a category its first keyword then remove the category placeholder string
            var categoryString = $"{keywordString.Split(',')[0]},";
            keywordStrings.Remove(categoryString);
            keywordStrings.Add(keywordString);
            WriteKeywordStrings(keywordStrings);
        }

        public static void EditCategory(string oldValue, string newValue)
        {
            if (string.IsNullOrWhiteSpace(oldValue))
            {
                throw new ArgumentException("oldValue is required", nameof(oldValue));
            }
            if (string.IsNullOrWhiteSpace(newValue))
            {
                throw new ArgumentException("newValue is required", nameof(newValue));
            }
            EditItem($"{oldValue},", $"{newValue},");
        }

        public static void EditKeyword(string oldValue, string newValue)
        {
            if (string.IsNullOrWhiteSpace(oldValue))
            {
                throw new ArgumentException("oldValue is required", nameof(oldValue));
            }
            if (string.IsNullOrWhiteSpace(newValue))
            {
                throw new ArgumentException("newValue is required", nameof(newValue));
            }
            EditItem($",{oldValue}", $",{newValue}");
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

        private static void EditItem(string oldValue, string newValue)
        {
            var newKeywordStrings = new SortedSet<string>();
            var oldKeywordStrings = ReadKeywordStrings();
            foreach (var oldKeywordString in oldKeywordStrings)
            {
                var newKeywordString = oldKeywordString.Replace(oldValue, newValue);
                newKeywordStrings.Add(newKeywordString);
            }
            WriteKeywordStrings(newKeywordStrings);
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

        private static void WriteKeywordStrings(SortedSet<string> keywordStrings)
        {
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