using System.Collections.Generic;
using App.Domain.Entities;

namespace App.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(int id);
        Product Get(string Title);
        IEnumerable<Product> GetAll();
        int Save(Product product);
        void Update(Product product);
    }
}