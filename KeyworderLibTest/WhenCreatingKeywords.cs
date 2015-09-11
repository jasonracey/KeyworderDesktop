using System.Linq;
using System.Xml.Linq;
using FluentAssertions;
using KeyworderLib;
using NUnit.Framework;

namespace KeyworderLibTest
{
    [TestFixture]
    public class WhenCreatingKeywords
    {
        [SetUp]
        public void SetUp()
        {
            TestData.Create();
        }

        [Test]
        public void CanCreateNewCategory()
        {
            const string testCategoryId = "TestCategory";
            KeywordRepository.CreateCategory(testCategoryId);
            KeywordRepository.GetCategories().Should()
                .Contain(c => c.CategoryId == testCategoryId);
        }

        [Test]
        public void CannotCreateDuplicateCategory()
        {
            var categoryWithAtLeastOneKeyword = KeywordRepository.GetCategories()
                .First(c => c.Keywords.Count > 0);
            var keywordCount = categoryWithAtLeastOneKeyword.Keywords.Count;
            var testCategoryId = categoryWithAtLeastOneKeyword.CategoryId;
            KeywordRepository.CreateCategory(testCategoryId);
            var unchangedCategory = KeywordRepository.GetCategories()
                .Single(c => c.CategoryId == testCategoryId);
            unchangedCategory.Keywords.Count.Should().Be(keywordCount);

            // also check file because sorted set only contains distinct items
            XDocument.Load("Keywords.xml")
                .Descendants("Category")
                .Count(e => e.Attribute("CategoryId").Value == testCategoryId)
                .Should().Be(1);
        }

        [Test]
        public void CanCreateNewKeyword()
        {
            var testCategoryId = KeywordRepository.GetCategories().First().CategoryId;
            const string testKeywordId = "TestKeyword";
            KeywordRepository.CreateKeyword(testCategoryId, testKeywordId);
            KeywordRepository.GetCategories().Single(c => c.CategoryId == testCategoryId)
                .Keywords.Should().Contain(k => k.KeywordId == testKeywordId);
        }

        [Test]
        public void CanCreateDuplicateKeywordInDifferentCategory()
        {
            var categories = KeywordRepository.GetCategories();
            var existingKeywordId = categories.First(c => c.Keywords.Count > 0)
                .Keywords.First().KeywordId;
            var differentCategoryId = categories.First(c => c.Keywords
                .All(k => k.KeywordId != existingKeywordId)).CategoryId;
            KeywordRepository.CreateKeyword(differentCategoryId, existingKeywordId);
            KeywordRepository.GetCategories().Single(c => c.CategoryId == differentCategoryId)
                .Keywords.Should().Contain(k => k.KeywordId == existingKeywordId);
        }

        [Test]
        public void CannotCreateDuplicateKeywordWithinCategory()
        {
            var categories = KeywordRepository.GetCategories();
            var testCategory = categories.First(c => c.Keywords.Count > 0);
            var testCategoryId = testCategory.CategoryId;
            var existingKeywordId = testCategory.Keywords.First().KeywordId;
            KeywordRepository.CreateKeyword(testCategoryId, existingKeywordId);
            XDocument.Load("Keywords.xml")
                .Descendants("Category").Single(e => e.Attribute("CategoryId").Value == testCategoryId)
                .Descendants("Keyword").Count(e => e.Attribute("KeywordId").Value == existingKeywordId)
                .Should().Be(1);
        }
    }
}
