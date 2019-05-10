using System;
using App.Domain.Enums;

namespace App.Domain.QueryResults.OrdersQuery
{
    public class GetOrderQuery
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Number { get; set; }
        public EOrderStatus Status { get; set; }
        public decimal Deliveryfee { get; set; }
        public decimal Discount { get; set; }
    }
}