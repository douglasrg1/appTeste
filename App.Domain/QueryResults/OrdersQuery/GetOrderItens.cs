using System;
using App.Domain.Enums;

namespace App.Domain.QueryResults.OrdersQuery
{
    public class GetOrderItens
    {
        public string Title { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}