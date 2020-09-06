using KeyworderLib;
using System.Collections.Generic;
using System.Linq;

namespace KeyworderLibTest
{
    internal class NoOpKeywordRepository : IKeywordRepository
    {
        public NoOpKeywordRepository()
        {
        }

        public void CreateCategory(string categoryId)
        {
            return;
        }

        public void CreateKeyword(string categoryId, string keywordId)
        {
            return;
        }

        public void DeleteCategory(string categoryId)
        {
            return;
        }

        public void DeleteKeyword(string categoryId, string keywordId)
        {
            return;
        }

        public IEnumerable<Category> GetCategories()
        {
            return Enumerable.Empty<Category>();
        }

        public void UpdateCategory(string oldCategoryId, string newCategoryId)
        {
            return;
        }

        public void UpdateKeyword(string categoryId, string oldKeywordId, string newKeywordId)
        {
            return;
        }
    }
}