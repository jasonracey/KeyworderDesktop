using System.Linq;
using FluentAssertions;
using KeyworderLib;
using NUnit.Framework;

namespace KeyworderLibTest
{
    [TestFixture]
    public class WhenDeletingKeywords
    {
        [SetUp]
        public void SetUp()
        {
            TestData.Create();
        }

        [Test]
        public void CanDeleteExistingCategory()
        {
            var testCategoryId = KeywordRepository.GetCategories().First().CategoryId;
            KeywordRepository.DeleteCategory(testCategoryId);
            KeywordRepository.GetCategories().Should()
                .NotContain(c => c.CategoryId == testCategoryId);
        }
        
        [Test]
        public void NoErrorWhenCategoryDoesntExist()
        {
            const string testCategoryId = "Foo";
            KeywordRepository.DeleteCategory(testCategoryId);
            KeywordRepository.GetCategories().Should()
                .NotContain(c => c.CategoryId == testCategoryId);
        }

        [Test]
        public void CanDeleteExistingKeyword()
        {
            var testCategory = KeywordRepository.GetCategories().First();
            var testCategoryId = testCategory.CategoryId;
            var testKeywordId = testCategory.Keywords.First().KeywordId;
            KeywordRepository.DeleteKeyword(testCategoryId, testKeywordId);
            KeywordRepository.GetCategories().Single(c => c.CategoryId == testCategoryId)
                .Keywords.Should().NotContain(k => k.KeywordId == testKeywordId);
        }

        [Test]
        public void NoErrorWhenKeywordDoesntExist()
        {
            var testCategory = KeywordRepository.GetCategories().First();
            var testCategoryId = testCategory.CategoryId;
            const string testKeywordId = "Foo";
            KeywordRepository.DeleteKeyword(testCategoryId, testKeywordId);
            KeywordRepository.GetCategories().Single(c => c.CategoryId == testCategoryId)
                .Keywords.Should().NotContain(k => k.KeywordId == testKeywordId);
        }
    }
}
