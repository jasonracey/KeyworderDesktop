using KeyworderLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace KeyworderLibTest
{
    [TestClass]
    public class TestBase
    {
        protected static string _path = GetNewPath();
        protected static KeywordRepository _keywordRepository = new KeywordRepository(_path);

        protected static string GetNewPath() => $"Keywords-{Guid.NewGuid()}.xml";

        [TestInitialize]
        public void TestInitialize()
        {
            _path = GetNewPath();
            TestData.Create(_path);
            _keywordRepository = new KeywordRepository(_path);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(_path))
                File.Delete(_path);
        }
    }
}
