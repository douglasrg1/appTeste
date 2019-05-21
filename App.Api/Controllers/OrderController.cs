using App.Domain.Commands.OrderCommand;
using App.Domain.Handlers;
using App.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly OrderCommandHandler _handler;
        public OrderController(IOrderRepository orderRepository,OrderCommandHandler handler)
        {
            _handler = handler;
            _orderRepository = orderRepository;
        } 

        [HttpGet]
        [Route("v1/orders")]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        [Route("v1/orders")]
        public IActionResult Post([FromBody] PlaceOrderCommand order)
        {
            var customer = User.Identity.Name;
            return Ok(_handler.Handler(order));
        }
    }
}