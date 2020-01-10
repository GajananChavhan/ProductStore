using ProductStore.Models;
using System.Collections.Generic;

namespace ProductStore.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(Category product);
        bool RemoveCategory(int id);
        Category GetCategoryById(int id);
        IEnumerable<Category> GetAllCategory();
    }
}