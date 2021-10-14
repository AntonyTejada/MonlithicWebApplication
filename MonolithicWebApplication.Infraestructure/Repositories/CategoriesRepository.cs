using MonolithicWebApplication.Business.Entities;
using MonolithicWebApplication.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonolithicWebApplication.Infraestructure.Repositories
{
    public class CategoriesRepository : IRepository<Category>
    {
        ApplicationDbContext _dbContext = new ApplicationDbContext();

        public void Delete(int id)
        {
            _dbContext.Remove(_dbContext.Categories.Single(p => p.IdCategory == id));
            _dbContext.SaveChanges();
        }

        public List<Category> Get()
        {
            return _dbContext.Categories.ToList();
        }

        public void Insert(Category newCategory)
        {
            _dbContext.Add(newCategory);
            _dbContext.SaveChanges();
        }

        public void Update(int id, Category updateCategory)
        {
            _dbContext.Update(updateCategory);
            _dbContext.SaveChanges();
        }
    }
}
