using App.Domain.Commands.OrderCommand;
using App.Domain.Entities;
using App.Domain.Repositories;
using App.Shared.Commands;
using Flunt.Notifications;

namespace App.Domain.Handlers
{
    public class OrderCommandHandler : Notifiable, ICommandHandler<PlaceOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(ICustomerRepository customerRepository,
                             IProductRepository productRepository,
                             IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public void Handler(PlaceOrderCommand command)
        {
            var customer = _customerRepository.Get(command.Customer);
            var order = new Order(customer,command.DeliveryFee,command.Discount);

            foreach(var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product,item.Quantity,item.Price));
            }

            AddNotifications(order.Notifications);

            if(order.Valid)
                _orderRepository.Save(order);
        }
    }
}