using System;
using App.Domain.Entities;

namespace App.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid Id);
    }
}