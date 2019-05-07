using App.Domain.Commands.CustomerCommands;
using App.Domain.Entities;
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
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("clientes")]
        public IActionResult Get()
        {
            return Ok(_customerRepository.Get(1));
        }
        [HttpPost]
        [Route("clientes")]
        public IActionResult Post([FromBody] RegisterCustomerCommand cliente)
        {
            return Ok();
        }
    }
}
