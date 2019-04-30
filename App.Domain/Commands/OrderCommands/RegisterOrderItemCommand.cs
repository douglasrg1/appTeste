using System;
using App.Shared.Commands;

namespace App.Domain.Commands.OrderCommand
{
    public class RegisterOrderItemCommand : ICommand
    {
        public RegisterOrderItemCommand(Guid product, decimal quantity, decimal price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
        }

        public Guid Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }

    }
}