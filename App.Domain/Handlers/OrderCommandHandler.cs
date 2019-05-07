using App.Domain.Commands;
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
        public ICommandResult Handler(PlaceOrderCommand command)
        {
            var customer = _customerRepository.Get(1);// todo aki, trocar o id do commando que está como guid para int
            var order = new Order(customer,command.DeliveryFee,command.Discount);

            foreach(var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product,item.Quantity,item.Price));
            }

            AddNotifications(order.Notifications);

            if(Invalid)
                return new CommandResult(false,"Os seguintes dados não foram informados corretamente",
                    Notifications);

            _orderRepository.Save(order);

            return new CommandResult(true,"Os dados foram adicionado com sucesso",
                new {Number = order.Number, Status = order.Status});
        }
    }
}