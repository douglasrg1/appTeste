using System;
using System.Collections.Generic;
using System.Linq;
using App.Domain.Entities;
using App.Domain.Repositories;
using App.Infra.Context;
using Dapper;

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
            return _context.Connection.Query<Product>(
                $"Select * From spGetProductById({id})"
            ).FirstOrDefault();
        }

        public Product Get(string Title)
        {
            return _context.Connection.Query<Product>(
                $"Select * From spGetProductByTitle({Title})"
            ).FirstOrDefault();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Connection.Query<Product>(
                "Select * From spGetAllProducts()"
            );
        }

        public int Save(Product product)
        {
            return _context.Connection.Query<int>(
                $"Select * From spSaveProduct('{product.Title}',{product.Price},{product.QuantityOnHand},'{product.Image}')"
            ).FirstOrDefault();
        }

        public void Update(Product product)
        {
             _context.Connection.Execute(
                $"Select * From spUpdateProduct({product.Id}'{product.Title}',{product.Price},{product.QuantityOnHand},'{product.Image}')"
            );
        }
    }
}