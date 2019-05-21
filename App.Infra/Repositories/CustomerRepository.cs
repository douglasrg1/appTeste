using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using App.Domain.Entities;
using App.Domain.QueryResults;
using App.Domain.QueryResults.CustomerQuery;
using App.Domain.Repositories;
using App.Domain.ValueObjects;
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
            var customerAux =  _context.Connection.Query<GetCustomerQuery>(
                $"select * from spgetcustomerbyid({id})"
            ).FirstOrDefault();

            var name = new Name(customerAux.Name.Split(' ')[0],customerAux.Name.Split(' ')[1]);
            var user = new User(customerAux.UserName,customerAux.Password,false);
            var document = new Document(customerAux.Document);
            var email = new Email(customerAux.Email);

            return new Customer(customerAux.Id,name,document,DateTime.Now,email,user);

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

            return _context.Connection.Query<GetCustomerQuery>(
                $"select * from spgetcustomerbyid({id})"
            ).FirstOrDefault();
            
        }

        public int Save(Customer customer)
        {
            var id =  _context.Connection.Query<int>(
                $"select * from spSaveCustomer('{customer.Name.FirstName}','{customer.Name.LastName}', '{customer.Email.Address}','{customer.Document.Number}')"
            ).FirstOrDefault();

            _context.Connection.Execute(
                $"select * from spSaveUser('{customer.User.UserName}','{customer.User.PassWord}',{customer.User.Active},{id})"
            );

            return id;
        }
    }
}