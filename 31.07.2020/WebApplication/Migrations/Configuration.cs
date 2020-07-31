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

            dataContext.Images.AddOrUpdate(new Image
            {
                Id = 1,
                Url = "https://lh3.googleusercontent.com/1qsLTTAB5NvqZ8bxFSJSPPPgK9mpNY0s-yll3QZzOBHGYVHnJ3R4zWtjQb6RTmKbLStNDV0Hlbg=w640-h400-e365",
                IsDeleted = false,
                CreateDate = DateTime.Now,
                DeleteDate = DateTime.Now,
                ModifyDate = DateTime.Now
            });

            dataContext.Images.AddOrUpdate(new Image
            {
                Id = 1,
                Url = "https://images.unsplash.com/photo-1500622944204-b135684e99fd?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80",
                IsDeleted = false,
                CreateDate = DateTime.Now,
                DeleteDate = DateTime.Now,
                ModifyDate = DateTime.Now
            });

            dataContext.Images.AddOrUpdate(new Image
            {
                Id = 1,
                Url = "https://image.winudf.com/v2/image/Y29tLnRydWVhcHBzLnNhbW15Lm5hdHVyZV9zY3JlZW5zaG90c18xXzlkNzdhMDlj/screen-1.jpg?fakeurl=1&type=.jpg",
                IsDeleted = false,
                CreateDate = DateTime.Now,
                DeleteDate = DateTime.Now,
                ModifyDate = DateTime.Now
            });

        }
    }
}
