using ProductStore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProductStore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly ProductDbContext Context;

        public CategoryRepository(ProductDbContext context)
        {
            Context = context;
        }

        public void AddCategory(Category category)
        {
            Context.Categories.Add(category);
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return Context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return Context.Categories.FirstOrDefault(p => p.Id == id);
        }

        public bool RemoveCategory(int id)
        {
            bool isDeleted = false;
            var category = Context.Categories.Include(c=>c.Products).FirstOrDefault(c=>c.Id == id);
            if (category != null && category.Products.Count() <= 0)
            {
                Context.Categories.Remove(category);
                isDeleted = true;
            }
            return isDeleted;
        }
    }
}