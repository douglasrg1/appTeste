using System;
using App.Domain.Entities;
using App.Domain.Repositories;
using App.Infra.Context;

namespace App.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDataContext _context;
        public ProductRepository(AppDataContext context)
        {
            _context = context;
        }
        public Product Get(int id)
        {
            return null;
        }
    }
}