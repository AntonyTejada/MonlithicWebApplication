using MonolithicWebApplication.Business.Entities;
using MonolithicWebApplication.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace MonolithicWebApplication.Infraestructure.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        ApplicationDbContext _dbContext = new ApplicationDbContext();

        public void Delete(int id)
        {
            //var entity = _dbContext.Products.FirstOrDefault(p => p.IdProduct == id));
            _dbContext.Remove(_dbContext.Products.Single(p => p.IdProduct == id));
            _dbContext.SaveChanges();
        }

        public List<Product> Get() {
            return _dbContext.Products.ToList();
        }

        public void Insert(Product newProduct)
        {
            _dbContext.Add(newProduct);
            _dbContext.SaveChanges();
        }

        public void Update(int id, Product updateProduct)
        {
            _dbContext.Update(updateProduct);
            _dbContext.SaveChanges();
        }
    }
}
