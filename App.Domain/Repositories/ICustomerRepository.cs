using System;
using System.Collections.Generic;
using App.Domain.Commands.CustomerCommands;
using App.Domain.Entities;
using App.Domain.QueryResults;
using App.Domain.QueryResults.CustomerQuery;

namespace App.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(int Id);
        GetCustomerQuery Get(string userName);
        GetCustomerQuery Get_customer_user(int Id);
        IEnumerable<ListCustomerQueryResult> GetAll();
        bool DocumentExists(string document);
        int Save(Customer customer);
    }
}