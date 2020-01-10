using ProductStore.Models;

namespace ProductStore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ProductDbContext Context;

        public UnitOfWork(ProductDbContext context)
        {
            Context = context;
        }

        public ICategoryRepository Categories
        {
            get;
            set;
        }

        public IProductRepository Products
        {
            get;
            set;
        }

        public void Complete()
        {
            Context.SaveChanges();
        }
    }
}