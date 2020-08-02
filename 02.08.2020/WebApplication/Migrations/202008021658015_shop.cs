namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.products_categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        IsDeleted = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        ModifyDate = c.DateTime(nullable: false, precision: 0),
                        DeleteDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(maxLength: 4000, storeType: "nvarchar"),
                        IsDeleted = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        ModifyDate = c.DateTime(nullable: false, precision: 0),
                        DeleteDate = c.DateTime(nullable: false, precision: 0),
                        ProductCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.products_categories", t => t.ProductCategory_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.ProductCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.products", "ProductCategory_Id", "dbo.products_categories");
            DropForeignKey("dbo.products", "CategoryId", "dbo.categories");
            DropIndex("dbo.products", new[] { "ProductCategory_Id" });
            DropIndex("dbo.products", new[] { "CategoryId" });
            DropTable("dbo.products");
            DropTable("dbo.products_categories");
        }
    }
}
