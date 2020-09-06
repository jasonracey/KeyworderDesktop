using System.Collections.Generic;

namespace KeyworderLib
{
    public interface IKeywordRepository
    {
        void CreateCategory(string categoryId);
        void CreateKeyword(string categoryId, string keywordId);
        void DeleteCategory(string categoryId);
        void DeleteKeyword(string categoryId, string keywordId);
        IEnumerable<Category> GetCategories();
        void UpdateCategory(string oldCategoryId, string newCategoryId);
        void UpdateKeyword(string categoryId, string oldKeywordId, string newKeywordId);
    }
}