using MonolithicWebApplication.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonolithicWebApplication.Infraestructure.Repositories
{
    public class ProductRepository : IRepository
    {
        ApplicationDbContext _dbContext = new ApplicationDbContext();
    }
}
