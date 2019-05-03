using System;
using App.Domain.Entities;
using App.Domain.QueryResults.CustomerQuery;

namespace App.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid Id);
        GetCustomerQuery Get(string username);
        bool DocumentExists(string document);
        void Save(Customer customer);
    }
}