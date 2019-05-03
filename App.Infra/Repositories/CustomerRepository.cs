using System;
using System.Data.SqlClient;
using System.Linq;
using App.Domain.Entities;
using App.Domain.QueryResults.CustomerQuery;
using App.Domain.Repositories;
using App.Infra.Context;
using Dapper;

namespace App.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDataContext _context;
        public CustomerRepository(AppDataContext context)
        {
            _context = context;
        }
        public bool DocumentExists(string document)
        {
            return _context.Customers.Any(x=>x.Document.Number == document);
        }

        public Customer Get(Guid Id)
        {
            return _context.Customers.Find(Id);
        }

        public GetCustomerQuery Get(string username)
        {
            //usando dapper

            using(var conn = new SqlConnection(@""))
            {
                conn.Open();
                return conn.Query<GetCustomerQuery>("").FirstOrDefault();
            }
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
        }
    }
}