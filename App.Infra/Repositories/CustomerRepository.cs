using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using App.Domain.Commands.CustomerCommands;
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
        public bool DocumentExists(string document)
        {
            return _context.Connection.Query<bool>(
                    $"select * from spCheckDocument('{document}')"
                ).FirstOrDefault();

        }

        public Customer Get(int id)
        {
            return _context.Connection.Query<Customer>(
                $"select * from spgetcustomerbyid({id})"
            ).FirstOrDefault();

        }

        public GetCustomerQuery Get(string userName)
        {
            return _context.Connection.Query<GetCustomerQuery>(
                $"select * from spGetCustomerByUserName('{userName}')"
            ).FirstOrDefault();
        }

        public IEnumerable<ListCustomerQueryResult> GetAll()
        {
            return _context.Connection
            .Query<ListCustomerQueryResult>(
                "spReturnListCustomer", null,
                commandType: CommandType.StoredProcedure);
        }

        public GetCustomerQuery Get_customer_user(int id)
        {
            //usando dapper
            // return _context.Connection.Query<GetCustomerQuery>(
            //     "spgetcustomerbyid",new{Id = id},
            //     commandType:CommandType.StoredProcedure
            // ).FirstOrDefault();

            return _context.Connection.Query<GetCustomerQuery>(
                $"select * from spgetcustomerbyid({id})"
            ).FirstOrDefault();
            
        }

        public int Save(Customer customer)
        {
            return _context.Connection.Query<int>(
                $"select * from spSaveCustomer('{customer.Name.FirstName}','{customer.Name.LastName}', '{customer.Email.Address}','{customer.Document.Number}')"
            ).FirstOrDefault();
        }
    }
}