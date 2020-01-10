using ProductStore.Dtos;
using ProductStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductStore.Repositories
{
    public class ProductRepository : IProductRepository
    {

        protected readonly ProductDbContext Context;

        public ProductRepository(ProductDbContext context)
        {
            Context = context;
        }
        public void AddProduct(Product product)
        {
            Context.Products.Add(product);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return Context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return Context.Products.FirstOrDefault(p=>p.Id == id);
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return Context.Products.Where(p => p.CategoryId == categoryId);
        }

        public ProductFormData GetProductsFormData()
        {
            var currency = Context.Currency.Select(c=>c.Name).ToList();
            var units = Context.Units.Select(c => c.Name).ToList();
            var productFormData = new ProductFormData { Unit= units, Currency=currency};
            return productFormData;
        }

        public bool RemoveProduct(int id)
        {
            bool isDeleted = false;
            var product = Context.Products.Find(id);
            if (product != null)
            {
                Context.Products.Remove(product);
                isDeleted = true;
            }
            return isDeleted;
                
        }
    }
}