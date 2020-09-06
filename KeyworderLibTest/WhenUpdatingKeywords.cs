using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeyworderLibTest
{
    [TestClass]
    public class WhenUpdatingKeywords : TestBase
    {
        [TestMethod]
        public void CanUpdateCategory()
        {
            // arrange
            const string newCategoryId = "TestCategory";
            var oldCategories = _keywordRepository.GetCategories();
            oldCategories.Should().NotContain(c => c.CategoryId == newCategoryId);
            var oldCategoryId = oldCategories.First().CategoryId;
            oldCategoryId.Should().NotBe(newCategoryId);

            // act
            _keywordRepository.UpdateCategory(oldCategoryId, newCategoryId);

            // assert
            var newCategories = _keywordRepository.GetCategories();
            newCategories.Should().NotContain(c => c.CategoryId == oldCategoryId);
            newCategories.Count(c => c.CategoryId == newCategoryId).Should().Be(1);
        }

        [TestMethod]
        public void ExceptionThrownWhenCategoryDoesntExist()
        {
            // arrange
            const string oldCategoryId = "Foo";
            const string newCategoryId = "Bar";
            _keywordRepository.GetCategories().Count(c => c.CategoryId == oldCategoryId).Should().Be(0);
            
            // act/assert
            Assert.ThrowsException<ArgumentException>(() => _keywordRepository.UpdateCategory(oldCategoryId, newCategoryId));
        }

        [TestMethod]
        public void CanUpdateKeyword()
        {
            // arrange
            const string newKeywordId = "TestKeyword";
            var category = _keywordRepository.GetCategories().First();
            var categoryId = category.CategoryId;
            var oldKeywordId = category.Keywords.First().KeywordId;
            category.Keywords.Count(k => k.KeywordId == oldKeywordId).Should().Be(1);
            category.Keywords.Should().NotContain(c => c.KeywordId == newKeywordId);
            oldKeywordId.Should().NotBe(newKeywordId);

            // act
            _keywordRepository.UpdateKeyword(categoryId, oldKeywordId, newKeywordId);

            // assert
            var newCategories = _keywordRepository.GetCategories();
            newCategories.Single(c => c.CategoryId == categoryId)
                .Keywords.Count(k => k.KeywordId == newKeywordId)
                .Should().Be(1);
            newCategories.Single(c => c.CategoryId == categoryId)
                .Keywords.Should()
                .NotContain(k => k.KeywordId == oldKeywordId);
        }

        [TestMethod]
        public void ExceptionThrownWhenKeywordDoesntExist()
        {
            // arrange
            const string oldKeywordId = "Foo";
            const string newKeywordId = "Bar";
            var cateogry = _keywordRepository.GetCategories().First();
            cateogry.Keywords.Count(k => k.KeywordId == oldKeywordId).Should().Be(0);

            // act/assert
            Assert.ThrowsException<ArgumentException>(() => _keywordRepository.UpdateKeyword(cateogry.CategoryId, oldKeywordId, newKeywordId));
        }
    }
}
