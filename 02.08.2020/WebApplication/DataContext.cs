using MySql.Data.EntityFramework;
using System.Data.Entity;
using WebApplication.Entities;

namespace WebApplication
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DataContext : DbContext
    {
       
        public DataContext() :base("DataContext")
        {
          
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}