using System.Collections.Generic;
using System.Data;
using System.Linq;
using App.Domain.Entities;
using App.Domain.QueryResults.OrdersQuery;
using App.Domain.Repositories;
using App.Infra.Context;
using Dapper;

namespace App.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDataContext _context;
        public OrderRepository(AppDataContext context)
        {
            _context = context;
        }

        public IEnumerable<GetListOrderQuery> GetAll()
        {
            return _context.Connection.Query<GetListOrderQuery>(
                "Select * From spGetListOrder()"
            );
        }

        public GetOrderQuery GetByNumber(string number)
        {
            return _context.Connection.Query<GetOrderQuery>(
                $"Select * From spGetOrderByNumber('{number}')"
            ).FirstOrDefault();
        }

        public IEnumerable<OrderItem> GetOrderItens(int idPedido)
        {
            return _context.Connection.Query<OrderItem>(
                $"Select * From spGetOrderItens('{idPedido}')"
            );
        }

        public void Save(Order order)
        {
            
        }

        public void Update(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}