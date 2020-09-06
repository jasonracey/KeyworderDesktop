using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeyworderLibTest
{
    [TestClass]
    public class WhenDeletingKeywords : TestBase
    {
        [TestMethod]
        public void CanDeleteExistingCategory()
        {
            // arrange
            var testCategoryId = _keywordRepository.GetCategories().First().CategoryId;

            // act
            _keywordRepository.DeleteCategory(testCategoryId);

            // assert
            _keywordRepository.GetCategories().Should()
                .NotContain(c => c.CategoryId == testCategoryId);
        }
        
        [TestMethod]
        public void NoErrorWhenCategoryDoesntExist()
        {
            // arrange
            const string testCategoryId = "Foo";

            // act
            _keywordRepository.DeleteCategory(testCategoryId);

            // assert
            _keywordRepository.GetCategories().Should()
                .NotContain(c => c.CategoryId == testCategoryId);
        }

        [TestMethod]
        public void CanDeleteExistingKeyword()
        {
            //arrange
            var testCategory = _keywordRepository.GetCategories().First();
            var testCategoryId = testCategory.CategoryId;
            var testKeywordId = testCategory.Keywords.First().KeywordId;

            // act
            _keywordRepository.DeleteKeyword(testCategoryId, testKeywordId);

            // assert
            _keywordRepository.GetCategories().Single(c => c.CategoryId == testCategoryId)
                .Keywords.Should().NotContain(k => k.KeywordId == testKeywordId);
        }

        [TestMethod]
        public void NoErrorWhenKeywordDoesntExist()
        {
            //arrange
            var testCategory = _keywordRepository.GetCategories().First();
            var testCategoryId = testCategory.CategoryId;
            const string testKeywordId = "Foo";

            // act
            _keywordRepository.DeleteKeyword(testCategoryId, testKeywordId);

            // assert
            _keywordRepository.GetCategories().Single(c => c.CategoryId == testCategoryId)
                .Keywords.Should().NotContain(k => k.KeywordId == testKeywordId);
        }
    }
}
