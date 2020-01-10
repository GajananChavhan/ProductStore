using System.Data.Entity;

namespace ProductStore.Models
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Currency> Currency { get; set; }

        public ProductDbContext() : base("DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasRequired<Category>(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(s => s.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
            .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("uspInsertProduct")
            .Parameter(pm => pm.CategoryId, "CategoryId")
            .Parameter(pm => pm.Name, "Name")
            .Parameter(pm => pm.Price, "Price")
            .Parameter(pm => pm.Unit, "Unit")
            .Parameter(pm => pm.Currency, "Currency")));

            modelBuilder.Entity<Product>()
            .MapToStoredProcedures(p => p.Update(sp => sp.HasName("uspUpdateProduct").
            Parameter(pm => pm.CategoryId, "CategoryId")
            .Parameter(pm => pm.Id, "ProductId")
            .Parameter(pm => pm.Name, "Name")
            .Parameter(pm => pm.Price, "Price")
            .Parameter(pm => pm.Unit, "Unit")
            .Parameter(pm => pm.Currency, "Currency")));

            modelBuilder.Entity<Product>()
            .MapToStoredProcedures(p => p.Delete(sp => sp.HasName("uspDeleteProduct")
            .Parameter(pm => pm.Id, "ProductId")));
        }
    }
}