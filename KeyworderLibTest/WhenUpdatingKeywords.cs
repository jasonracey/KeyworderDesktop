using System;
using System.Linq;
using FluentAssertions;
using KeyworderLib;
using NUnit.Framework;

namespace KeyworderLibTest
{
    [TestFixture]
    public class WhenUpdatingKeywords
    {
        [SetUp]
        public void SetUp()
        {
            TestData.Create();
        }

        [Test]
        public void CanUpdateCategory()
        {
            const string newCategoryId = "TestCategory";
            var oldCategories = KeywordRepository.GetCategories();
            oldCategories.Should().NotContain(c => c.CategoryId == newCategoryId);
            var oldCategoryId = oldCategories.First().CategoryId;
            oldCategoryId.Should().NotBe(newCategoryId);
            KeywordRepository.UpdateCategory(oldCategoryId, newCategoryId);
            var newCategories = KeywordRepository.GetCategories();
            newCategories.Should().NotContain(c => c.CategoryId == oldCategoryId);
            newCategories.Count(c => c.CategoryId == newCategoryId).Should().Be(1);
        }

        [Test]
        public void ExceptionThrownWhenCategoryDoesntExist()
        {
            const string oldCategoryId = "Foo";
            const string newCategoryId = "Bar";
            KeywordRepository.GetCategories().Count(c => c.CategoryId == oldCategoryId).Should().Be(0);
            Assert.That(() => KeywordRepository.UpdateCategory(oldCategoryId, newCategoryId), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void CanUpdateKeyword()
        {
            const string newKeywordId = "TestKeyword";
            var category = KeywordRepository.GetCategories().First();
            var categoryId = category.CategoryId;
            var oldKeywordId = category.Keywords.First().KeywordId;
            category.Keywords.Count(k => k.KeywordId == oldKeywordId).Should().Be(1);
            category.Keywords.Should().NotContain(c => c.KeywordId == newKeywordId);
            oldKeywordId.Should().NotBe(newKeywordId);
            KeywordRepository.UpdateKeyword(categoryId, oldKeywordId, newKeywordId);
            var newCategories = KeywordRepository.GetCategories();
            newCategories.Single(c => c.CategoryId == categoryId)
                .Keywords.Count(k => k.KeywordId == newKeywordId)
                .Should().Be(1);
            newCategories.Single(c => c.CategoryId == categoryId)
                .Keywords.Should()
                .NotContain(k => k.KeywordId == oldKeywordId);
        }

        [Test]
        public void ExceptionThrownWhenKeywordDoesntExist()
        {
            const string oldKeywordId = "Foo";
            const string newKeywordId = "Bar";
            var cateogry = KeywordRepository.GetCategories().First();
            cateogry.Keywords.Count(k => k.KeywordId == oldKeywordId).Should().Be(0);
            Assert.That(() => KeywordRepository.UpdateKeyword(cateogry.CategoryId, oldKeywordId, newKeywordId), Throws.TypeOf<ArgumentException>());
        }
    }
}
