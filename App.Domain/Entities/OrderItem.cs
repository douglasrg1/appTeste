using App.Shared.Entity;
using Flunt.Validations;

namespace App.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity, decimal price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Product,"Produto","O produto deve ser informado")
                .IsGreaterThan(Quantity,0,"Quantity","A quantidade deve ser maior que 0")
                .IsGreaterOrEqualsThan(product.QuantityOnHand,quantity,"QuantityOnHand","A quantidade do produto não esta disponivel em estoque")
            );
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }


        public decimal Total() => Price * Quantity;

    }
}