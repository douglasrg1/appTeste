using System;
using System.Collections.Generic;
using App.Domain.Entities;
using App.Domain.QueryResults;
using App.Domain.QueryResults.CustomerQuery;

namespace App.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid Id);
        GetCustomerQuery Get(string username);
        IEnumerable<ListCustomerQueryResult> GetAll();
        bool DocumentExists(string document);
        void Save(Customer customer);
    }
}