using System;
using System.Collections;
using System.Collections.Generic;
using App.Shared.Commands;

namespace App.Domain.Commands.OrderCommand
{
    public class PlaceOrderCommand : ICommand
    {
        public PlaceOrderCommand(int customer, decimal deliveryFee, decimal discount)
        {
            Customer = customer;
            DeliveryFee = deliveryFee;
            Discount = discount;
        }

        public int Customer { get; private set; }
        public decimal DeliveryFee { get; private set; }
        public decimal Discount { get; private set; }
        public IEnumerable<RegisterOrderItemCommand> Items { get; private set; }
    }
}