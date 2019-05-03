using App.Domain.Entities;
using App.Domain.Repositories;
using App.Infra.Context;

namespace App.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDataContext _context;
        public OrderRepository(AppDataContext context)
        {
            _context = context;
        }
        public void Save(Order order)
        {
            _context.Orders.Add(order);
        }
    }
}