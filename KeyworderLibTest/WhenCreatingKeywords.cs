using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using FluentAssertions;
using KeyworderLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeyworderLibTest
{
    [TestClass]
    public class WhenCreatingKeywords
    {
        private string _path = string.Empty;
        private IKeywordRepository _keywordRepository = new NoOpKeywordRepository();

        [TestInitialize]
        public void TestInitialize()
        {
            _path = $"Keywords-{Guid.NewGuid()}.xml";
            TestData.Create(_path);
            _keywordRepository = new KeywordRepository(_path);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(_path))
                File.Delete(_path);
        }

        [TestMethod]
        public void CanCreateNewCategory()
        {
            // arrange
            const string testCategoryId = "TestCategory";
            _keywordRepository.CreateCategory(testCategoryId);
            _keywordRepository.GetCategories().Should()
                .Contain(c => c.CategoryId == testCategoryId);
        }

        [TestMethod]
        public void CannotCreateDuplicateCategory()
        {
            // arrange
            var categoryWithAtLeastOneKeyword = _keywordRepository.GetCategories()
                .First(c => c.Keywords.Count > 0);
            var keywordCount = categoryWithAtLeastOneKeyword.Keywords.Count;
            var testCategoryId = categoryWithAtLeastOneKeyword.CategoryId;

            // act
            _keywordRepository.CreateCategory(testCategoryId);

            // assert
            var unchangedCategory = _keywordRepository.GetCategories()
                .Single(c => c.CategoryId == testCategoryId);
            unchangedCategory.Keywords.Count.Should().Be(keywordCount);

            // also check file because sorted set only contains distinct items
            XDocument.Load(_path)
                .Descendants("Category")
                .Count(e => e.Attribute("CategoryId").Value == testCategoryId)
                .Should().Be(1);
        }

        [TestMethod]
        public void CanCreateNewKeyword()
        {
            // arrange
            var testCategoryId = _keywordRepository.GetCategories().First().CategoryId;
            const string testKeywordId = "TestKeyword";

            // act
            _keywordRepository.CreateKeyword(testCategoryId, testKeywordId);

            // assert
            _keywordRepository.GetCategories().Single(c => c.CategoryId == testCategoryId)
                .Keywords.Should().Contain(k => k.KeywordId == testKeywordId);
        }

        [TestMethod]
        public void CanCreateDuplicateKeywordInDifferentCategory()
        {
            // arrange
            var categories = _keywordRepository.GetCategories();
            var existingKeywordId = categories.First(c => c.Keywords.Count > 0)
                .Keywords.First().KeywordId;
            var differentCategoryId = categories.First(c => c.Keywords
                .All(k => k.KeywordId != existingKeywordId)).CategoryId;

            // act
            _keywordRepository.CreateKeyword(differentCategoryId, existingKeywordId);

            // assert
            _keywordRepository.GetCategories().Single(c => c.CategoryId == differentCategoryId)
                .Keywords.Should().Contain(k => k.KeywordId == existingKeywordId);
        }

        [TestMethod]
        public void CannotCreateDuplicateKeywordWithinCategory()
        {
            // arrange
            var categories = _keywordRepository.GetCategories();
            var testCategory = categories.First(c => c.Keywords.Count > 0);
            var testCategoryId = testCategory.CategoryId;
            var existingKeywordId = testCategory.Keywords.First().KeywordId;

            // act
            _keywordRepository.CreateKeyword(testCategoryId, existingKeywordId);

            // assert
            XDocument.Load(_path)
                .Descendants("Category").Single(e => e.Attribute("CategoryId").Value == testCategoryId)
                .Descendants("Keyword").Count(e => e.Attribute("KeywordId").Value == existingKeywordId)
                .Should().Be(1);
        }
    }
}
