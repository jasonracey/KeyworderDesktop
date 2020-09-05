using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace KeyworderLib
{
    public class KeywordRepository
    {
        private readonly string _keywordsXmlPath;

        public KeywordRepository(string keywordsXmlPath)
        {
            if (string.IsNullOrWhiteSpace(keywordsXmlPath))
            {
                throw new ArgumentNullException(nameof(keywordsXmlPath));
            }

            if (!File.Exists(keywordsXmlPath))
            {
                throw new ArgumentException("file not found", nameof(keywordsXmlPath));
            }

            _keywordsXmlPath = keywordsXmlPath;
        }

        public void CreateKeyword(string categoryId, string keywordId)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
            {
                throw new ArgumentException("categoryId is required", nameof(categoryId));
            }
            if (string.IsNullOrWhiteSpace(keywordId))
            {
                throw new ArgumentException("keywordId is required", nameof(keywordId));
            }
            var document = XDocument.Load(_keywordsXmlPath);
            var category = document.Descendants("Category")
                .Single(d => d.Attribute("CategoryId").Value == categoryId);
            if (category.Descendants("Keyword")
                .Count(d => d.Attribute("KeywordId").Value == keywordId) == 0)
            {
                category.Add(new XElement("Keyword", new XAttribute("KeywordId", keywordId)));
                document.Save(_keywordsXmlPath);
            }
        }

        public void CreateCategory(string categoryId)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
            {
                throw new ArgumentException("categoryId is required", nameof(categoryId));
            }
            var document = XDocument.Load(_keywordsXmlPath);
            if (document.Descendants("Category")
                .Count(d => d.Attribute("CategoryId").Value == categoryId) == 0)
            {
                document.Root?.Add(new XElement("Category", new XAttribute("CategoryId", categoryId)));
                document.Save(_keywordsXmlPath);
            }
        }

        public void DeleteKeyword(string categoryId, string keywordId)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
            {
                throw new ArgumentException("categoryId is required", nameof(categoryId));
            }
            if (string.IsNullOrWhiteSpace(keywordId))
            {
                throw new ArgumentException("keywordId is required", nameof(keywordId));
            }
            var document = XDocument.Load(_keywordsXmlPath);
            if (document.Descendants("Category")
                    .Single(d => d.Attribute("CategoryId").Value == categoryId)
                    .Descendants("Keyword")
                    .Count(d => d.Attribute("KeywordId").Value == keywordId) > 0)
            {
                document.Descendants("Category")
                    .Single(d => d.Attribute("CategoryId").Value == categoryId)
                    .Descendants("Keyword")
                    .Single(d => d.Attribute("KeywordId").Value == keywordId)
                    .Remove();
                document.Save(_keywordsXmlPath);
            }
        }

        public void DeleteCategory(string categoryId)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
            {
                throw new ArgumentException("categoryId is required", nameof(categoryId));
            }
            var document = XDocument.Load(_keywordsXmlPath);
            if (document.Descendants("Category")
                .Count(d => d.Attribute("CategoryId").Value == categoryId) > 0)
            {
                document.Descendants("Category")
                    .Single(d => d.Attribute("CategoryId").Value == categoryId)
                    .Remove();
                document.Save(_keywordsXmlPath);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = new SortedSet<Category>(new CategoryComparer());
            foreach (var categoryNode in XDocument.Load(_keywordsXmlPath).Descendants("Category"))
            {
                var categoryId = categoryNode.Attribute("CategoryId").Value;
                var category = new Category(categoryId);
                foreach (var keywordNode in categoryNode.Elements("Keyword"))
                {
                    var keywordId = keywordNode.Attribute("KeywordId").Value;
                    category.Keywords.Add(new Keyword(categoryId, keywordId));
                }
                categories.Add(category);
            }
            return categories;
        }

        public void UpdateKeyword(string categoryId, string oldKeywordId, string newKeywordId)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
            {
                throw new ArgumentException("categoryId is required", nameof(categoryId));
            }
            if (string.IsNullOrWhiteSpace(oldKeywordId))
            {
                throw new ArgumentException("oldKeywordId is required", nameof(oldKeywordId));
            }
            if (string.IsNullOrWhiteSpace(newKeywordId))
            {
                throw new ArgumentException("newKeywordId is required", nameof(newKeywordId));
            }
            var document = XDocument.Load(_keywordsXmlPath);
            var keyword = document.Descendants("Category")
                .Single(d => d.Attribute("CategoryId").Value == categoryId)
                .Descendants("Keyword")
                .SingleOrDefault(d => d.Attribute("KeywordId").Value == oldKeywordId);
            if (keyword == null)
            {
                throw new ArgumentException("keyword not found", oldKeywordId);
            }
            keyword.SetAttributeValue("KeywordId", newKeywordId);
            document.Save(_keywordsXmlPath);
        }

        public void UpdateCategory(string oldCategoryId, string newCategoryId)
        {
            if (string.IsNullOrWhiteSpace(oldCategoryId))
            {
                throw new ArgumentException("oldCategoryId is required", nameof(oldCategoryId));
            }
            if (string.IsNullOrWhiteSpace(newCategoryId))
            {
                throw new ArgumentException("newCategoryId is required", nameof(newCategoryId));
            }
            var document = XDocument.Load(_keywordsXmlPath);
            var category = document.Descendants("Category")
                .SingleOrDefault(d => d.Attribute("CategoryId")
                .Value == oldCategoryId);
            if (category == null)
            {
                throw new ArgumentException("category not found", oldCategoryId);
            }
            category.SetAttributeValue("CategoryId", newCategoryId);
            document.Save(_keywordsXmlPath);
        }
    }
}