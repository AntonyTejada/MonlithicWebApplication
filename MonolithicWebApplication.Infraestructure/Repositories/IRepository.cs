using MonolithicWebApplication.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonolithicWebApplication.Infraestructure.Repositories
{
    public interface IRepository<T>
    {
        List<T> Get();

        void Insert(T newEntity);

        void Update(int id, T updateEntity);

        void Delete(int id);
    }
}
