using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeyworderLibTest
{
    [TestClass]
    public class WhenGettingKeywords : TestBase
    {
        [TestMethod]
        public void CanGetCategories()
        {
            // act
            var categories = _keywordRepository.GetCategories();

            // assert
            categories.Count().Should().BeGreaterThan(0);
            foreach (var category in categories)
            {
                category.Should().NotBeNull();
                category.CategoryId.Should().NotBeNullOrWhiteSpace();
                category.Keywords.Should().NotBeNull();
                foreach (var keyword in category.Keywords)
                {
                    keyword.Should().NotBeNull();
                    keyword.CategoryId.Should().Be(category.CategoryId);
                    keyword.KeywordId.Should().NotBeNullOrWhiteSpace();
                }
            }
        }
    }
}
