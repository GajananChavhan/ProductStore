using ProductStore.Dtos;
using ProductStore.Models;
using System.Collections.Generic;

namespace ProductStore.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        bool RemoveProduct(int id);
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProduct();
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
        ProductFormData GetProductsFormData();
    }
}