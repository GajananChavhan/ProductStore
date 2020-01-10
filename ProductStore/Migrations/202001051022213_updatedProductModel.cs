namespace ProductStore.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updatedProductModel : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.uspInsertProduct",
                p => new
                    {
                        Name = p.String(maxLength: 200),
                        Unit = p.String(maxLength: 20),
                        Price = p.Decimal(precision: 18, scale: 2),
                        Currency = p.String(maxLength: 20),
                        CategoryId = p.Int(),
                    },
                body:
                    @"BEGIN TRAN
                      INSERT [dbo].[Products]([Name], [Unit], [Price], [Currency], [CategoryId])
                      VALUES (@Name, @Unit, @Price, @Currency, @CategoryId)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Products]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Products] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id
                      COMMIT TRAN"
            );
            
            CreateStoredProcedure(
                "dbo.uspUpdateProduct",
                p => new
                    {
                        ProductId = p.Int(),
                        Name = p.String(maxLength: 200),
                        Unit = p.String(maxLength: 20),
                        Price = p.Decimal(precision: 18, scale: 2),
                        Currency = p.String(maxLength: 20),
                        CategoryId = p.Int(),
                    },
                body:

                     @"BEGIN TRAN
                      UPDATE [dbo].[Products]
                      SET [Name] = @Name, [Unit] = @Unit, [Price] = @Price, [Currency] = @Currency, [CategoryId] = @CategoryId
                      WHERE ([Id] = @ProductId)
                      COMMIT TRAN"
            );
            
            CreateStoredProcedure(
                "dbo.uspDeleteProduct",
                p => new
                    {
                        ProductId = p.Int(),
                    },
                body:
                   @"BEGIN TRAN
                     DELETE [dbo].[Products]
                     WHERE ([Id] = @ProductId)
                     COMMIT TRAN"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.uspDeleteProduct");
            DropStoredProcedure("dbo.uspUpdateProduct");
            DropStoredProcedure("dbo.uspInsertProduct");
        }
    }
}
