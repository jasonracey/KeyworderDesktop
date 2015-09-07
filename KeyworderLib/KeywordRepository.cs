using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            var categoryString = $"{category},";
            var keywordStrings = ReadKeywordStrings();
            if (keywordStrings.Any(keywordString => keywordString.StartsWith(categoryString)))
            {
                return;
            }
            keywordStrings.Add(categoryString);
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
            if (keywordStrings.Any(s => s == keywordString))
            {
                return;
            }
            // if user has assigned a category its first keyword then remove the category placeholder string
            var categoryString = $"{keywordString.Split(',')[0]},";
            keywordStrings.Remove(categoryString);
            keywordStrings.Add(keywordString);
            WriteKeywordStrings(keywordStrings);
        }

        public static void DeleteCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException("category is required", nameof(category));
            }
            var keywordStrings = ReadKeywordStrings();
            keywordStrings.RemoveWhere(s => s.StartsWith($"{category},"));
            WriteKeywordStrings(keywordStrings);
        }

        public static void DeleteKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new ArgumentException("keyword is required", nameof(keyword));
            }
            
            var keywordStrings = ReadKeywordStrings();
            // don't delete the category if there's no more keywords in it
            var searchString = $",{keyword}";
            var matchingKeywordStrings = keywordStrings.Where(s => s.EndsWith(searchString));
            var categoriesOfMatchingKeywordStrings = new Dictionary<string,string>();
            foreach (var matchingKeywordString in matchingKeywordStrings)
            {
                var parts = matchingKeywordString.Split(',');
                if (!categoriesOfMatchingKeywordStrings.ContainsKey(parts[0]))
                {
                    categoriesOfMatchingKeywordStrings.Add(parts[0], null);
                }
            }
            keywordStrings.RemoveWhere(s => s.EndsWith(searchString));
            foreach (var category in categoriesOfMatchingKeywordStrings.Keys)
            {
                keywordStrings.Add($"{category},");
            }
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
            EditItems($"{oldValue},", $"{newValue},");
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
            EditItems($",{oldValue}", $",{newValue}");
        }

        public static SortedDictionary<string, SortedSet<string>> GetKeywordsGroupedByCategory()
        {
            var keywordsGroupedByCategory = new SortedDictionary<string, SortedSet<string>>();
            foreach (var keywordString in ReadKeywordStrings())
            {
                var parts = keywordString.Split(',');
                var category = parts[0];
                var keyword = parts.Length == 2 ? parts[1] : string.Empty;
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

        private static void EditItems(string oldValue, string newValue)
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

        private static void WriteKeywordStrings(IEnumerable<string> keywordStrings)
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