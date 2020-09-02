using System;
using System.IO;
using FluentAssertions;
using KeyworderLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeyworderLibTest
{
    [TestClass]
    public class WhenGettingKeywords
    {
        private string _path;
        private KeywordRepository _keywordRepository;

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
        public void CanGetCategories()
        {
            // act
            var categories = _keywordRepository.GetCategories();

            // assert
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
