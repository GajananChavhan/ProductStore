namespace ProductStore.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; set; }
        ICategoryRepository Categories { get; set; }
        void Complete();
    }
}