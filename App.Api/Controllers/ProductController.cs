using App.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    public class ProductController: Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("v1/produtos")]
        public IActionResult Get()
        {
            return Ok(_productRepository.Get(1));
        }

    }
}