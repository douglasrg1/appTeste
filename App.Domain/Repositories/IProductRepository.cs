using System;
using System.Collections.Generic;
using App.Domain.Entities;

namespace App.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
    }
}