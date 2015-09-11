using FluentAssertions;
using KeyworderLib;
using NUnit.Framework;

namespace KeyworderLibTest
{
    [TestFixture]
    public class WhenGettingKeywords
    {
        [SetUp]
        public void SetUp()
        {
            TestData.Create();
        }

        [Test]
        public void CanGetCategories()
        {
            var categories = KeywordRepository.GetCategories();
            categories.Count.Should().BeGreaterThan(0);
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
