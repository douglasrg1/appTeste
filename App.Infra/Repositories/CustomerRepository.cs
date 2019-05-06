using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using App.Domain.Entities;
using App.Domain.QueryResults;
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
        public bool DocumentExists(string Document)
        {
            return _context.Connection.Query<bool>(
                    "spCheckDocument", new { document = Document },
                    commandType: CommandType.StoredProcedure
                ).FirstOrDefault();
        }

        public Customer Get(Guid Id)
        {
            return null;
        }
        public IEnumerable<ListCustomerQueryResult> GetAll()
        {
            return _context.Connection
            .Query<ListCustomerQueryResult>(
                "spReturnListCustomer", null,
                commandType: CommandType.StoredProcedure);
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
            
        }
    }
}