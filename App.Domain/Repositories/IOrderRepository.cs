using System.Collections.Generic;
using App.Domain.Entities;
using App.Domain.QueryResults.OrdersQuery;

namespace App.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
        IEnumerable<GetListOrderQuery> GetAll();
        GetOrderQuery GetByNumber(string number);
        void Update(Order order);
        IEnumerable<OrderItem> GetOrderItens(int idPedido);
    }
}