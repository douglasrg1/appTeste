using App.Domain.Commands.CustomerCommands;
using App.Domain.Entities;
using App.Domain.Handlers;
using App.Domain.Repositories;
using App.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerCommandHandler _handler;
        public CustomerController(CustomerCommandHandler handler,ICustomerRepository customerRepository)
        {
            _handler = handler;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("clientes")]
        public IActionResult Get()
        {
            return Ok(_customerRepository.GetAll());
        }
        [HttpPost]
        [Route("clientes")]
        public IActionResult Post([FromBody] RegisterCustomerCommand customer)
        {
            return Ok(_handler.Handler(customer));
        }
    }
}
