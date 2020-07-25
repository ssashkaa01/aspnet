namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new myMigrationSQLGenerator());
        }

        protected override void Seed(WebApplication.DataContext dataContext)
        {
            
                dataContext.Categories.AddOrUpdate(new Category
                {
                    Id = 1,
                    Name = "Category1",
                    IsDeleted = false,
                    CreateDate = DateTime.Now,
                    DeleteDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                });

                dataContext.Categories.AddOrUpdate(new Category
                {
                    Id = 2,
                    Name = "Category2",
                    IsDeleted = false,
                    CreateDate = DateTime.Now,
                    DeleteDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                });

                dataContext.Posts.AddOrUpdate(new Entities.Post
                {
                    Id = 1,
                    Title = "Title 1",
                    Description = "Text bla bla bla",
                    CategoryId = 1,
                    IsDeleted = false,
                    CreateDate = DateTime.Now,
                    DeleteDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                });

                dataContext.Posts.AddOrUpdate(new Entities.Post
                {
                    Id = 2,
                    Title = "Title 2",
                    Description = "Text bla bla bla",
                    CategoryId = 1,
                    IsDeleted = false,
                    CreateDate = DateTime.Now,
                    DeleteDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                });
               
        }
    }
}
