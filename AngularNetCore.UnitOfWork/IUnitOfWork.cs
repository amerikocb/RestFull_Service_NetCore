﻿using AngularNetCore.Repositories;

namespace AngularNetCore.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IUserRepository User { get; }
        ISupplierRepository Supplier { get; }
        IOrderRepository Order { get;}
    }
}
