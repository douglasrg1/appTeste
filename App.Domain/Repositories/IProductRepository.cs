using App.Domain.Entities;

namespace App.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(int id);
    }
}