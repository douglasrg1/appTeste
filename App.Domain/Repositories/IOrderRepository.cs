using App.Domain.Entities;

namespace App.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}