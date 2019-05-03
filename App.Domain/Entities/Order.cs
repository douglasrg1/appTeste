using System;
using System.Collections.Generic;
using System.Linq;
using App.Domain.Enums;
using App.Shared.Entity;
using Flunt.Validations;

namespace App.Domain.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;

        protected Order()
        {
            
        }
        public Order(Customer customer,decimal deliveryfee, decimal discount)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0,8);
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            Deliveryfee = deliveryfee;
            Discount = discount;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterOrEqualsThan(Deliveryfee,0,"DelveryFee","O valor de entrega deve ser maior ou igual a 0")
                .IsGreaterOrEqualsThan(Discount,0,"Discount","O disconto deve ser igual ou maior que 0")
            );
            AddNotifications(Customer.Notifications);
        }

        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public ICollection<OrderItem> Items { get{return _items.ToArray();}}
        public decimal Deliveryfee { get; private set; }
        public decimal Discount { get; private set; }
        
        public decimal SubTotal() => Items.Sum(x=>x.Total());

        public decimal Total()=> SubTotal() + Deliveryfee - Discount;

        public void AddItem(OrderItem item)
        {
            AddNotifications(item.Notifications);
            
            if(item.Valid)
            {
                _items.Add(item);
                item.Product.DecreaseQuantity(item.Quantity);

            }
        }

        public void PlaceOrder()
        {
            
        }
    }
}