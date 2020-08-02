using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApplication.Entities;

namespace WebApplication.DAL.Repositories
{
    public class CategoryRepository : IRepository<ProductCategory>
    {
        DataContext db;
        public CategoryRepository()
        {
            db = new DataContext();
        }
        public IEnumerable<ProductCategory> GetAll(Expression<Func<ProductCategory, bool>> filter = null)
        {
            var query = db.ProductCategories.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }

        public ProductCategory Get(int id)
        {
            return db.ProductCategories.Find(id);
        }

        public void Create(ProductCategory item)
        {
            db.ProductCategories.Add(item);
        }

        public void Update(ProductCategory item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ProductCategory item = db.ProductCategories.Find(id);
            if (item != null)
                db.ProductCategories.Remove(item);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}